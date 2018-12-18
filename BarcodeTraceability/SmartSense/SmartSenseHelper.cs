// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Laborie">
//   Copyright (c) Laborie. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Laborie.Synergy.BarcodeTraceability.SmartSense
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using HardwareManager.Interfaces;
    using Model;
    using SmartSenseCore.Domain.DataModels;
    using SmartSenseCore.Domain.MetaDataModels;
    using SmartSenseSynergy;

    public class SmartSenseHelper : ISmartSenseHelper
    {
        private readonly ISmartSenseSecure smartSenseSecure;
        private readonly ManufacturerServiceStub manufacturerService;

        public SmartSenseHelper()
        {
            manufacturerService = new ManufacturerServiceStub();
            smartSenseSecure = SmartSenseFactory.CreateSmartSenseSecure(manufacturerService);
        }

        public List<BarcodeModel> Decode(byte[] encryptedBytes)
        {
            var consumableItems = smartSenseSecure.Decode(encryptedBytes);

            var barcodeModels = new List<BarcodeModel>();

            foreach (var consumableItem in consumableItems)
            {
                var barcodeModel = ConvertConsumableItemToBarcodeModel(consumableItem);
                barcodeModel.EncryptedBytes = encryptedBytes;
                barcodeModels.Add(barcodeModel);
            }

            return barcodeModels;
        }

        public List<BarcodeModel> Decode(IRfidTag rfidTag)
        {
            if (rfidTag.Data == null || rfidTag.Bytes == null)
                return new List<BarcodeModel>();

            return Decode(rfidTag.Bytes);
        }

        public byte[] Encode(BarcodeModel barcodeModel)
        {
            var consumableItems = ConvertBarcodeModelToConsumableItem(barcodeModel);

            if (consumableItems == null) return null;
            
            ManufacturerInfo manufacturerInfo = manufacturerService.GetManufacturerInfo(1);
            var overallDataLayout = smartSenseSecure.Encode(manufacturerInfo.EncryptionScheme, consumableItems);

            return overallDataLayout.ContinuousBlockBytes;
        }

        private BarcodeModel ConvertConsumableItemToBarcodeModel(ConsumableItem consumableItem)
        {
            var barcodeModel = new BarcodeModel();
            foreach (var item in Enum.GetValues(typeof(ElementNames)))
            {
                object consumableElement = GetConsumableElement(consumableItem, (ElementNames)item);
                if (consumableElement == null) continue;

                switch (item)
                {
                    case ElementNames.TagId:
                        {
                            barcodeModel.TagId = (byte[])consumableElement;
                            break;
                        }

                    case ElementNames.Gtin:
                        {
                            var gtin = ((ulong)consumableElement).ToString();
                            if (gtin.Length < 14)
                            {
                                gtin = gtin.PadLeft(14, '0');
                            }

                            barcodeModel.GTIN = gtin;
                            break;
                        }

                    case ElementNames.LotNumber:
                        {
                            barcodeModel.Lot = (string)consumableElement;
                            break;
                        }

                    case ElementNames.SerialNumber:
                        {
                            barcodeModel.Serial = (string)consumableElement;
                            break;
                        }

                    case ElementNames.DateOfManufacture:
                        {
                            barcodeModel.ProductionDate = (DateTime)consumableElement;
                            break;
                        }

                    case ElementNames.ExpiryDate:
                        {
                            barcodeModel.ExpiryDate = (DateTime)consumableElement;
                            break;
                        }

                    case ElementNames.StartOfUse:
                        {
                            barcodeModel.UsedDate = (DateTime)consumableElement;
                            break;
                        }

                    case ElementNames.PatientId:
                        {
                            barcodeModel.PatientGuid = (string)consumableElement;
                            break;
                        }

                    case ElementNames.PartNumber:
                    {
                        barcodeModel.TypeName = (string)consumableElement;
                        break;
                    }

                    case ElementNames.PatientIdCrc:
                    {
                        barcodeModel.PatientIdCrc = (byte[])consumableElement;
                        break;
                    }

                    case ElementNames.Color:
                    {
                        barcodeModel.Color = (int)consumableElement;
                        break;
                    }
                }
            }

            return barcodeModel;
        }

        private ConsumableItem[] ConvertBarcodeModelToConsumableItem(BarcodeModel barcodeModel)
        {
            var consumableItems = new List<ConsumableItem>();

            if (barcodeModel.EncryptedBytes != null)
            {
                consumableItems.AddRange(smartSenseSecure.Decode(barcodeModel.EncryptedBytes).ToList());

                foreach (var consumableItem in consumableItems)
                {
                    var elementToRemove = consumableItem.Elements.FirstOrDefault(e => e.Name == ElementNames.StartOfUse);
                    consumableItem.Elements.Remove(elementToRemove);

                    if (barcodeModel.UsedDate != null)
                    {
                        var smartSenseElement = SmartSenseElement.StartOfUse(barcodeModel.UsedDate.Value);
                        consumableItem.Elements.Add(smartSenseElement);
                    }

                    elementToRemove = consumableItem.Elements.FirstOrDefault(e => e.Name == ElementNames.PatientIdCrc);
                    consumableItem.Elements.Remove(elementToRemove);

                    if (barcodeModel.PatientIdCrc != null)
                    {
                        var smartSenseElement = SmartSenseElement.PatientIdCrc(barcodeModel.PatientIdCrc);
                        consumableItem.Elements.Add(smartSenseElement);
                    }
                }
            }
            else
            {
                IList<SmartSenseElement> elements = new List<SmartSenseElement>();
                elements.Add(SmartSenseElement.TagId(barcodeModel.TagId));
                elements.Add(SmartSenseElement.Gtin(Convert.ToUInt64(barcodeModel.GTIN)));

                if (!string.IsNullOrEmpty(barcodeModel.TypeName))
                    elements.Add(SmartSenseElement.PartNumber(barcodeModel.TypeName));

                if (Enum.IsDefined(typeof(TypeEnums), barcodeModel.Type))
                {
                    elements.Add(SmartSenseElement.ConsumableType((TypeEnums)barcodeModel.Type));
                }

                if (Enum.IsDefined(typeof(ColorEnums), barcodeModel.Color))
                {
                    elements.Add(SmartSenseElement.Color((ColorEnums)barcodeModel.Color));
                }

                if (barcodeModel.Lot != string.Empty)
                {
                    elements.Add(SmartSenseElement.LotNumber(barcodeModel.Lot));
                }

                if (barcodeModel.Serial != string.Empty)
                {
                    elements.Add(SmartSenseElement.SerialNumber(barcodeModel.Serial));
                }

                if (barcodeModel.ProductionDate != null)
                {
                    var year = (ushort)barcodeModel.ProductionDate.Value.Year;
                    var month = (byte)barcodeModel.ProductionDate.Value.Month;
                    var day = (byte)barcodeModel.ProductionDate.Value.Day;
                    elements.Add(SmartSenseElement.DateOfManufacture(year, month, day));
                }

                if (barcodeModel.ExpiryDate != null)
                {
                    var year = (ushort)barcodeModel.ExpiryDate.Value.Year;
                    var month = (byte)barcodeModel.ExpiryDate.Value.Month;
                    var day = (byte)barcodeModel.ExpiryDate.Value.Day;
                    elements.Add(SmartSenseElement.ExpiryDate(year, month, day));
                }

                if (barcodeModel.UsedDate != null)
                {
                    elements.Add(SmartSenseElement.StartOfUse(barcodeModel.UsedDate.Value));
                }

                if (barcodeModel.PatientIdCrc != null)
                {
                    elements.Add(SmartSenseElement.PatientIdCrc(barcodeModel.PatientIdCrc));
                }

                ConsumableItem item1 = new ConsumableItem(elements);
                consumableItems.Add(item1);
            }

            return consumableItems.ToArray();
        }

        private object GetConsumableElement(ConsumableItem consumableItem, ElementNames elementName)
        {
            return consumableItem.Elements.Where(x => x.Name == elementName).Select(z => z.Value).SingleOrDefault();
        }
    }
}
