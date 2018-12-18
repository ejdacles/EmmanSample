// <copyright file="ConsumableValidator.cs" company="Laborie">
// Copyright (c) Laborie. All rights reserved.
// </copyright>

namespace Laborie.Synergy.BarcodeTraceability
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using DataModel;
    using DataStorage.Interfaces;
    using Exceptions;
    using HardwareManager.Device;
    using Laborie.SmartSenseCore.Domain.MetaDataModels;
    using Model;
    using Translations;

    public class ConsumableValidator : IConsumableValidator
    {
        private readonly IConsumableMatrixHelper consumableHelper;
        
        public ConsumableValidator(IBarcodeRepository repository)
        {
            consumableHelper = Factory.Instance.GetConsumableMatrixHelper();
            BarcodeRepository = repository;
        }

        public IBarcodeRepository BarcodeRepository { get; }

        public bool Validate(BarcodeModel consumableModel, ReadPatients_Result currentPatient, IEnumerable<BarcodeModel> barcodeList, IEnumerable<InvestigationConsumable> requiredConsumables)
        {
            if (!ValidateLotAndSerialNumber(consumableModel))
            {
                throw new InvalidConsumableException(Language.Error_OverflowException);
            }

            if (!ValidateGtin(consumableModel))
            {
                throw new InvalidConsumableException(Language.Error_ConsumableWithUnknownCategory);
            }

            if (!ValidateExpiry(consumableModel))
            {
                throw new InvalidConsumableException(Language.Error_ConsumableExpired);
            }

            if (!ValidateBarcodeUsage(consumableModel, currentPatient))
            {
                if (!ValidateConsumablePatientUsage(consumableModel, currentPatient))
                {
                    throw new InvalidConsumableException(Language.Error_ConsumableIsUsedByOtherPatientException);
                }

                if (!ValidateConsumableTimeLimit(consumableModel, currentPatient))
                {
                    throw new InvalidConsumableException(Language.Error_ConsumableTimeLimitExpiredException);
                }
            }

            if (!ValidateRequiredConsumables(consumableModel, requiredConsumables))
            {
                throw new InvalidConsumableException(Language.Error_ConsumableWithUnwantedCategory);
            }

            if (!ValidateConsumableIfDuplicate(consumableModel, barcodeList))
            {
                throw new InvalidConsumableException(Language.Error_ConsumableWithDuplicateBarcodeExistsException);
            }

            return true;
        }

        private bool ValidateLotAndSerialNumber(BarcodeModel consumableModel)
        {
            return !(consumableModel.Serial?.Length > 20) && !(consumableModel.Lot?.Length > 20);
        }

        private bool ValidateGtin(BarcodeModel consumableModel)
        {
            var consumableType = consumableHelper.GetConsumableType(consumableModel);

            return consumableType != null;
        }

        private bool ValidateExpiry(BarcodeModel consumableModel)
        {
            return consumableModel?.ExpiryDate > DateTime.Now;
        }

        private bool ValidateBarcodeUsage(BarcodeModel consumableModel, ReadPatients_Result currentPatient)
        {
            var existingConsumable = BarcodeRepository.GetBarcode(Convert.ToInt64(consumableModel.GTIN), consumableModel.TagId);

            return consumableModel.PatientIdCrc == null && consumableModel.UsedDate == null && existingConsumable == null;
        }

        private bool ValidateConsumablePatientUsage(BarcodeModel consumableModel, ReadPatients_Result currentPatient)
        {
            if (currentPatient == null) return true;

            var newBarcodeGtin = Convert.ToInt64(consumableModel.GTIN);
            var currentPatientDbId = currentPatient.DbId;
            var currentPatientGuid = currentPatient.Uuid.ToString();

            if (consumableModel.PatientGuid?.Length > 0 && !consumableModel.PatientGuid.Equals(currentPatientGuid, StringComparison.InvariantCultureIgnoreCase))
            {
                return false;
            }
            else if (consumableModel.PatientIdCrc != null)
            {
                var curPatientIdBytes = Encoding.UTF8.GetBytes(currentPatientGuid);
                var curPatientIdCrc16 = General.CalculateCRC16(curPatientIdBytes, (ushort)curPatientIdBytes.Length);

                if (curPatientIdCrc16 != BitConverter.ToUInt16(consumableModel.PatientIdCrc, 0)) return false;
            }
            else
            {
                var testResult = BarcodeRepository.GetBarcodeTests(newBarcodeGtin, consumableModel.TagId);

                if (testResult == null) return true;

                var barcodeProceduresAssignedToOtherPatients = testResult.Where(t =>
                    t.Study.patient_id != currentPatientDbId);

                if (barcodeProceduresAssignedToOtherPatients.Any()) return false;
            }

            return true;
        }

        private bool ValidateConsumableTimeLimit(BarcodeModel consumableModel, ReadPatients_Result currentPatient)
        {
            if (currentPatient == null)
            {
                return true;
            }

            var newBarcodeGtin = Convert.ToInt64(consumableModel.GTIN);
            var consumableType = consumableHelper.GetConsumableType(consumableModel);
            var currentPatientDbId = currentPatient.DbId;

            if (consumableType == null || consumableType.TimeLimit == -1)
            {
                return true;
            }
            else if (consumableModel.UsedDate != null)
            {
                var hours = (DateTime.Now - consumableModel.UsedDate).Value.TotalHours;

                if (hours > consumableType.TimeLimit)
                {
                    return false;
                }
            }
            else
            {
                var testResult = BarcodeRepository.GetBarcodeTests(newBarcodeGtin, consumableModel.TagId);

                if (testResult == null) return true;

                var barcodeProceduresAssignedToCurrentPatient = testResult.Where(t => t.Study.patient_id == currentPatientDbId);

                if (!barcodeProceduresAssignedToCurrentPatient.Any()) return true;

                var procedureTime = barcodeProceduresAssignedToCurrentPatient.First().test_time;
                var hours = (DateTime.Now - procedureTime).TotalHours;

                if (hours > consumableType.TimeLimit) return false;
            }

            return true;
        }

        private bool ValidateRequiredConsumables(BarcodeModel consumableModel, IEnumerable<InvestigationConsumable> requiredConsumables)
        {
            var consumableType = consumableHelper.GetConsumableType(consumableModel);

            if (consumableType?.QualifyLevel == QualifyType.Qualified)
            {
                if (requiredConsumables != null)
                {
                    var investigationConsumables = requiredConsumables.ToList();

                    if (consumableModel.Color == (int)ColorEnums.Yellow && consumableType.PuraCatheter)
                    {
                        var puraConsumable = investigationConsumables.FirstOrDefault(c =>
                            c.IsScanned == false && c.RequiredCategory.Category == ConsumableCategory.PuraCatheter);

                        return puraConsumable != null;
                    }
                    else
                    {
                        foreach (var consumable in investigationConsumables)
                        {
                            if (IsConsumableTypeMatched(consumableModel, consumable.RequiredCategory, consumableType) ==
                                QualifyType.Unknown)
                            {
                                continue;
                            }

                            // if all this consumable and its alternative consumables are not scanned, the consumableType is needed
                            if (!consumable.IsScanned)
                            {
                                var requiredCategory = consumable.RequiredCategory;

                                var alternativeConsumables = investigationConsumables.Where(x =>
                                    x.RequiredCategory.Exclusive
                                    && x.RequiredCategory.InvestigationType == requiredCategory.InvestigationType
                                    && x.RequiredCategory.ChannelType == requiredCategory.ChannelType
                                    && x.RequiredCategory.Category != requiredCategory.Category);

                                if (!alternativeConsumables.Any(x => x.IsScanned)) return true;
                            }
                        }
                    }
                }
            }
            else
            {
                return true;
            }

            return false;
        }

        private QualifyType IsConsumableTypeMatched(BarcodeModel consumableModel, ChannelConsumableCategory requiredCategory, ConsumableType consumableType)
        {
            var categories = InvestigationConsumable.GetSupportedCategories(consumableType, consumableModel.Color);
            return categories.Any(x => x.Equals(requiredCategory.Category)) ? requiredCategory.QualifyLevel : QualifyType.Unknown;
        }

        private bool ValidateConsumableIfDuplicate(BarcodeModel consumableModel, IEnumerable<BarcodeModel> barcodeList)
        {
            var newBarcodeGtin = Convert.ToInt64(consumableModel.GTIN);

            var existingBarcode = barcodeList.FirstOrDefault(b =>
                Convert.ToInt64(b.GTIN) == newBarcodeGtin &&
                b.Color == consumableModel.Color);

            return existingBarcode == null;
        }
    }
}