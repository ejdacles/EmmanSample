// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Laborie">
//   Copyright (c) Laborie. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Laborie.Synergy.BarcodeTraceability
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Windows.Media.Imaging;
    using Common;
    using Common.ApplicationLogging;
    using DataModel;
    using DataStorage.Interfaces;
    using Exceptions;
    using HardwareManager.Device;
    using HardwareManager.Device.Roam;
    using HardwareManager.Interfaces;
    using Laborie.SmartSenseCore.Domain.MetaDataModels;
    using Laborie.Synergy.Common.Security;
    using Laborie.Synergy.Common.Services;
    using Laborie.Synergy.Common.UI.Models;
    using Laborie.Synergy.PatientManager;
    using LicenseManager;
    using Model;
    using ProcedureManager.Interfaces;
    using RfidReader;
    using SmartSense;
    using Translations;

    /// <summary>
    /// Barcode traceability manager
    /// </summary>
    public class BarcodeTraceabilityManager : BindableBase, IBarcodeTraceabilityManager
    {
        private const string GTIN14Format = "0000000000000#";

        private static readonly object DbAccessLock = new object();
        private static readonly object DbSaveLock = new object();

        private readonly ILicenseExecutor licenseExecutor;
        private readonly ConsumableMatrixHelper consumableHelper;
        private readonly ILogger logger = Common.Factory.Instance.CreateApplicationLogger(typeof(BarcodeTraceabilityManager));       
        private readonly IConsumableValidator consumableValidator;
        private readonly IDictionary<int, string> errorMessage;

        private bool isBypassUsed;
        private bool isScanning;
        private bool recordStarted;
        private bool isBarCodeScanCompleted;
        private IEnumerable<InvestigationConsumable> requiredConsumables;
        private IEnumerable<BarcodeModel> barcodeList;
        private int newConsumableCount;
        private ISmartSenseHelper smartSenseHelper;
        private PhaseModel currentPreviewPhase;
        private PhaseModel currentPhase;
        private IEnumerable<ChannelModel> availableChannels;
        private IEnumerable<InvestigationConsumable> allRequiredConsumables;
        private PatientContext patientContext;
        private IShowModalessDialog dialog;

        /// <summary>
        /// Initializes a new instance of the <see cref="BarcodeTraceabilityManager"/> class.
        /// </summary>
        /// <param name="barcodeRepository">The repository containing all available barcodes</param>
        /// <param name="protocol">The Protocol Model</param>
        /// <param name="consumableBarcodeManager">The Consumable Barcode Manager</param>
        public BarcodeTraceabilityManager(IBarcodeRepository barcodeRepository, ProtocolModel protocol, IConsumableBarcodeManager consumableBarcodeManager)
        {
            BarcodeRepository = barcodeRepository;
            Protocol = protocol;
            ConsumableBarcodeManager = consumableBarcodeManager;

            licenseExecutor = Synergy.LicenseManager.Factory.Instance.GetLicenseExecutor();
            consumableHelper = Factory.Instance.GetConsumableMatrixHelper();
            smartSenseHelper = new SmartSenseHelper();

            IsBypassUsed = false;
            RecordStarted = false;
            NewConsumableCount = 0;
            requiredConsumables = new List<InvestigationConsumable>();
            barcodeList = new List<BarcodeModel>();
            errorMessage = new Dictionary<int, string>();

            consumableValidator = new ConsumableValidator(BarcodeRepository);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BarcodeTraceabilityManager"/> class.
        /// </summary>
        /// <param name="unitOfWork">Unit of work containing all repositories</param>
        public BarcodeTraceabilityManager(IUnitOfWork unitOfWork) : this(unitOfWork.BarcodeRepository, null, null)
        {
        }

        /// <summary>
        /// Gets or sets the RfidManager Instance
        /// </summary>
        public RfidManager RfidManager { get; set; }

        /// <summary>
        /// Gets or sets the SmartSenseHelper Instance
        /// </summary>
        public ISmartSenseHelper SmartSenseHelper
        {
            get => smartSenseHelper;
            set => smartSenseHelper = value;
        }

        /// <summary>
        /// Gets or sets a value indicating whether or not it is for Review.
        /// </summary>
        public bool Review { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Barcode scan is completed.
        /// </summary>
        public bool IsBarCodeScanCompleted
        {
            get => isBarCodeScanCompleted;

            set
            {
                isBarCodeScanCompleted = value;
                OnPropertyChanged(nameof(IsBarCodeScanCompleted));
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the recording is started.
        /// </summary>
        public bool RecordStarted
        {
            get => recordStarted;

            set
            {
                recordStarted = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the Bypass is used for current procedure
        /// </summary>
        public bool IsBypassUsed
        {
            get => isBypassUsed;

            set
            {
                isBypassUsed = value;
                OnPropertyChanged(nameof(IsBypassUsed));
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the Bypass is used for current procedure
        /// </summary>
        public bool IsScanning
        {
            get => isScanning;

            set
            {
                isScanning = value;
                OnPropertyChanged(nameof(IsScanning));
            }
        }

        /// <summary>
        /// Gets Required Consumables
        /// </summary>
        public IEnumerable<InvestigationConsumable> RequiredConsumables
        {
            get => requiredConsumables;

            private set
            {
                requiredConsumables = value;
                OnPropertyChanged(nameof(RequiredConsumables));
            }
        }

        /// <summary>
        /// Gets or sets Barcode list
        /// </summary>
        public IEnumerable<BarcodeModel> BarcodeList
        {
            get => barcodeList;

            set
            {
                barcodeList = value;                
                OnPropertyChanged(nameof(BarcodeList));
            }
        }

        /// <summary>
        /// Gets or sets Barcode Review list
        /// </summary>
        public IEnumerable<BarcodeModel> BarcodeReviewList { get; set; }

        /// <summary>
        /// Gets the Barcode Traceability repository.
        /// </summary>
        public IBarcodeRepository BarcodeRepository { get; }

        /// <summary>
        /// Gets or sets the current Protocol Model
        /// </summary>
        public ProtocolModel Protocol { get; set; }

        /// <summary>
        /// Gets or sets the consumable barcode manager.
        /// </summary>
        public IConsumableBarcodeManager ConsumableBarcodeManager { get; set; }

        public string ErrorMessage
        {
            get
            {
                var message = string.Empty;
                foreach (var item in errorMessage)
                {
                    message = message + item.Value;
                }

                return message.Trim('\r', '\n');
            }
        }

        /// <summary>
        /// Gets current Bypass Count from license 
        /// </summary>
        public int BypassCount => licenseExecutor.GetByPassCount();

        /// <summary>
        /// Gets or sets a value indicating the number of new Consumables scanned
        /// </summary>
        public int NewConsumableCount
        {
            get => newConsumableCount;

            set
            {
                newConsumableCount = value;
                OnPropertyChanged();
            }
        }

        public IRfidInventory RfidInventory { get; set; }

        public IPimService PimService { get; set; }

        public void OnPhaseStart(PhaseModel phase)
        {
            currentPhase = phase;
            patientContext = Synergy.PatientManager.Factory.Instance.GetPatientManager().PatientContext;

            if (currentPhase.PhaseType != PhaseModelTypes.PreviewPhase)
                return;

            currentPreviewPhase = currentPhase;
            allRequiredConsumables = GetAllRequiredConsumables();
            availableChannels = GetRelevantChannelsForCurrentPreviewSequence();

            InitConsumables(patientContext?.CurrentStudy?.ID, patientContext?.CurrentPatient?.DbId, patientContext?.CurrentPatient?.Uuid.ToString());
            UpdateSmartSenseInventory(RfidInventory);
        }

        /// <summary>
        /// Reset the list of barcodes when the procedure ends.
        /// </summary>
        public void OnProcedureEnd()
        {
            errorMessage.Clear();
            barcodeList = new List<BarcodeModel>();
            requiredConsumables = new List<InvestigationConsumable>();
            RfidInventory = null;
            availableChannels = null;
        }

        /// <summary>
        /// Save the barcode to the database
        /// </summary>
        /// <param name="consumableModel">Consumable modelu</param>
        /// <param name="patientUuid">UUID of current patient</param>
        /// <returns>Database id of the new generated barcode</returns>
        public int SaveBarcode(BarcodeModel consumableModel, string patientUuid)
        {
            bool isTagWritten = true;
            Consumable existingBarcode = null;

            lock (DbSaveLock)
            {
                if (consumableModel.QualifyLevelType != (int)QualifyLevelType.Other && consumableModel.TagId != null)
                {
                    ConsumableType consumableType = consumableHelper.GetConsumableType(consumableModel);

                    var investigationConsumables = requiredConsumables.ToList();

                    // if already exists in database, get it; if not, save the new barcode.
                    existingBarcode = BarcodeRepository.GetBarcode(
                        Convert.ToInt64(consumableModel.GTIN),
                        consumableModel.TagId);

                    if (existingBarcode == null)
                    {
                        if (investigationConsumables.Any(consumble =>
                            IsConsumableTypeMatched(consumble.RequiredCategory, consumableType) ==
                            QualifyType.Qualified))
                        {
                            NewConsumableCount++;
                        }
                    }
                }
            }

            var barcodeId = existingBarcode?.BarcodeID;
            if (existingBarcode == null)
            {
                var consumable = new Consumable
                {
                    TagId = consumableModel.TagId,
                    Gtin = Convert.ToInt64(consumableModel.GTIN),
                    ProductionDate = consumableModel.ProductionDate,
                    ExpirationDate = consumableModel.ExpiryDate,
                    Lot = consumableModel.Lot,
                    Serial = consumableModel.Serial,
                    CategoryName = consumableModel.CategoryName,
                    TypeName = consumableModel.TypeName,
                    Description = consumableModel.Description,
                    QualifyLevel = consumableModel.QualifyLevel,
                    QualifyLevelType = consumableModel.QualifyLevelType,
                    ScanDate = DateTime.Now
                };

                if (consumableModel.EncryptedBytes != null)
                {
                    if (consumableModel.UsedDate == null)
                        consumableModel.UsedDate = DateTime.Now;

                    consumable.UsedDate = consumableModel.UsedDate.Value;

                    if (!string.IsNullOrEmpty(patientUuid))
                    {
                        consumable.PatientId = new Guid(patientUuid);
                        var patientIdBytes = Encoding.UTF8.GetBytes(patientUuid);
                        var patientIdCrc16 = General.CalculateCRC16(patientIdBytes, (ushort)patientIdBytes.Length);
                        consumableModel.PatientIdCrc = BitConverter.GetBytes(patientIdCrc16);
                    }

                    isTagWritten = WriteSmartSenseTag(consumableModel, out byte[] data);
                    consumableModel.EncryptedBytes = data;
                    consumable.EncryptedBytes = consumableModel.EncryptedBytes;
                }

                if (isTagWritten)
                {
                    barcodeId = BarcodeRepository?.AddBarcode(consumable, patientUuid);
                }
            }

            if (barcodeId.HasValue)
            {
                consumableModel.BarCodeId = barcodeId.Value;
                consumableModel.IsWritten = true;

                // if RecordStarted, the Procedure Test-Barcode relationship is saved immediately
                // ortherwise, the Procedure Test-Barcode relationship would be saved while starting record later.
                if (RecordStarted)
                {
                    ConsumableBarcodeManager?.AssignConsumablesToProcedure(BarcodeList.Select(b => b.BarCodeId));
                }
            }

            return barcodeId.GetValueOrDefault();
        }

        public void UpdateConsumableList(BarcodeModel consumableModel)
        {
            RegisterBarcode(consumableModel, requiredConsumables);
            BarcodeList = Helper.Append(barcodeList, consumableModel);
            OnPropertyChanged(nameof(RequiredConsumables));
            IsBarCodeScanCompleted = IsAllScanCompleted();
        }

        /// <summary>
        /// remove the barcode from barcode List
        /// </summary>
        /// <param name="barcodeId">barCode Id</param>
        public void RemoveBarcode(int barcodeId)
        {
            var consumableModel = barcodeList.FirstOrDefault(b => b.BarCodeId == barcodeId);

            if (consumableModel != null) DeleteConsumable(consumableModel);
        }

        /// <summary>
        /// Validate the barcode information
        /// </summary>
        /// <param name="currentPatientDbId">Patient database id</param>
        /// <param name="barcode">barcode model</param>
        public void ValidateArbitraryBarcode(int currentPatientDbId, BarcodeModel barcode)
        {
            // Arbitrary Barcode expired
            if (barcode.ExpiryDate != null && barcode.ExpiryDate < DateTime.Now)
            {
                throw new InvalidConsumableException(Language.Error_ConsumableExpired);
            }
        }

        /// <summary>
        /// Validate the barcode information
        /// </summary>
        /// <param name="currentPatientDbId">Patient database id</param>
        /// <param name="currentPatientGuid">patient ID</param>
        /// <param name="barcode">barcode model</param>
        public void ValidateBarcode(int currentPatientDbId, string currentPatientGuid, BarcodeModel barcode)
        {
            consumableValidator.Validate(barcode, patientContext?.CurrentPatient, BarcodeList, requiredConsumables);
        }

        /// <summary>
        /// Get Required Consumable list according to the current Protocol channel settings.
        /// </summary>
        /// <returns>collection of Consumable category</returns>
        public IEnumerable<InvestigationConsumable> GetRequiredConsumables()
        {
            var consumables = new List<InvestigationConsumable>();

            if (availableChannels == null)
                availableChannels = Protocol?.ChannelModels;

            foreach (var channel in availableChannels)
            {
                var channelConsumableCategories = consumableHelper.GetChannelConsumableCategory(Protocol.InvestigationType, channel.ChannelType);

                consumables.AddRange(channelConsumableCategories.Select(category => new InvestigationConsumable()
                {
                    RequiredCategory = new ChannelConsumableCategory()
                    {
                        InvestigationType = category.InvestigationType,
                        ChannelType = category.ChannelType,
                        Category = category.Category,
                        QualifyLevel = category.QualifyLevel,
                        Exclusive = category.Exclusive
                    }
                }));
            }

            return consumables;
        }

        /// <summary>
        /// Gets all tests Barcodes of the Study. 
        /// </summary>
        /// <param name="studyId">Study ID</param>
        /// <param name="patientUuid">Current patient Uuid</param>
        /// <param name="forReport">True if call from Reporter</param>
        /// <returns>list of barcode model</returns>
        public IEnumerable<BarcodeModel> GetTestBarcodes(int studyId, string patientUuid, bool forReport = false)
        {
            var barcodeModels = new List<BarcodeModel>();
            var barcodes = BarcodeRepository?.GetPatientTestBarcodes(studyId, patientUuid);

            if (barcodes != null && barcodes.Any())
            {
                foreach (var barcode in barcodes)
                {
                    var gtin = barcode.Gtin ?? 0;

                    BarcodeModel barcodeReviewModel = new BarcodeModel()
                    {
                        BarCodeId = barcode.BarcodeID,
                        GTIN = gtin.ToString(GTIN14Format),
                        ProductionDate = barcode.ProductionDate,
                        ExpiryDate = barcode.ExpirationDate,
                        Lot = barcode.Lot,
                        Serial = barcode.Serial,
                        CategoryName = barcode.CategoryName,
                        TypeName = barcode.TypeName,
                        Description = barcode.Description,
                        QualifyLevel = barcode.QualifyLevel ?? 0,
                        TagId = barcode.TagId
                    };

                    ConsumableType consumableType = consumableHelper.GetConsumableType(barcodeReviewModel);
                    if (consumableType != null)
                    {
                        barcodeReviewModel.QualifyLevelType = (int)consumableType.QualifyLevelType;
                    }
                    else
                    {
                        barcodeReviewModel.QualifyLevelType = (int)QualifyLevelType.Other;
                    }

                    barcodeModels.Add(barcodeReviewModel);

                    if (!forReport)
                    {
                        RegisterBarcode(barcodeReviewModel, RequiredConsumables);
                    }
                }
            }

            return barcodeModels;
        }

        /// <summary>
        /// To initialize the Barcode List for a study.
        /// </summary>
        /// <param name="studyId">study Id</param>
        /// <param name="patientUuid">Current patient UUID</param>
        public void InitReviewConsumables(int studyId, string patientUuid)
        {
            availableChannels = Protocol?.ChannelModels;
            RequiredConsumables = GetRequiredConsumables();
            BarcodeReviewList = GetTestBarcodes(studyId, patientUuid);
            IsBarCodeScanCompleted = IsAllScanCompleted();
            IsBypassUsed = BarcodeRepository.GetIsConsumableBypass(studyId);
        }

        /// <summary>
        /// use the Consumable Bypass, decrease the Bypass count in license 
        /// </summary>
        public void UseBypass()
        {
            if (!IsBypassUsed)
            {
                IsBypassUsed = true;

                licenseExecutor.UseByPass();

                IsBarCodeScanCompleted = true;
            }
        }

        public void PimServiceOnInventoryScanDone(object sender, IRfidInventoryUpdate rfidInventoryUpdate)
        {
            // Update Consumable Traceability of new RfidInventory     
            if (rfidInventoryUpdate.RfidInventoryStatus == RfidInventoryStatus.ReadCompleted)
            {
                RfidInventory = rfidInventoryUpdate.RfidInventory;
                UpdateSmartSenseInventory(RfidInventory);
            }
        }

        public void PimServiceOnConsumerChanged(object sender, IRfidTagUpdate rfidTagUpdate)
        {
            // Update Consumable Traceability of new RfidInventory     
            if (currentPhase?.PhaseType == PhaseModelTypes.PreviewPhase)
            {
                if (rfidTagUpdate.RfidTagStatus == RfidTagStatus.Removed)
                {
                    var consumableModel = BarcodeList.FirstOrDefault(b => b.Index == rfidTagUpdate.RfidTag.Index);

                    if (consumableModel != null)
                    {
                        DeleteConsumable(consumableModel);
                    }
                    else
                    {
                        if (rfidTagUpdate.RfidTag != null)
                            errorMessage.Remove(rfidTagUpdate.RfidTag.Index);

                        IsBarCodeScanCompleted = IsAllScanCompleted();
                    }
                }
                else if (rfidTagUpdate.RfidTagStatus == RfidTagStatus.Inserted)
                {
                    NativeMethods.PlaySound(NativeMethods.SoundType.START_SOUND);
                    IsScanning = true;
                }
            }
        }

        public void PimServiceOnServiceDataReceived(object sender, ISmartSenseTag smartSenseTag)
        {
            if (smartSenseTag?.EntireEncodingBytes != null)
            {
                ProcessSmartSenseTag(smartSenseTag);
            }
        }

        public void UpdateSmartSenseInventory(IRfidInventory rfidInventory)
        {
            if (rfidInventory == null || currentPhase?.PhaseType != PhaseModelTypes.PreviewPhase || availableChannels == null) return;

            var rfidTags = rfidInventory.RfidTags.Where(x => x.IsInitialized && x.TagId != 0);
            foreach (var rfidTag in rfidTags)
            {
                ProcessSmartSenseTag(rfidTag.SmartSenseTag);
            }

            IsScanning = false;            
        }

        public void ProcessSmartSenseTag(ISmartSenseTag smartSenseTag)
        {
            if (smartSenseTag.EntireEncodingBytes == null) return;

            var consumable = new ConsumableType();
            var currentConsumableModel = new BarcodeModel();
            errorMessage.Remove(smartSenseTag.Index);

            try
            {
                var decodedBarcodeModels = smartSenseHelper.Decode(smartSenseTag.EntireEncodingBytes);
                if (decodedBarcodeModels == null) return;

                logger.Info(GetLogMessage("ReadSmartSenseTag", decodedBarcodeModels));

                foreach (var decodedBarcodeModel in decodedBarcodeModels)
                {
                    decodedBarcodeModel.Index = smartSenseTag.Index;
                    currentConsumableModel = decodedBarcodeModel;
                    consumable = consumableHelper.GetConsumableType(currentConsumableModel);

                    // Check if consumable is already in the Consumable List
                    var newBarcodeGtin = Convert.ToInt64(currentConsumableModel.GTIN);

                    if (currentConsumableModel.TagId != null)
                    {
                        var existingBarcode = barcodeList.FirstOrDefault(b =>
                            Convert.ToInt64(b.GTIN) == newBarcodeGtin &&
                            b.TagId.SequenceEqual(currentConsumableModel.TagId));

                        if (existingBarcode != null)
                        {
                            if ((QualifyLevelType)existingBarcode.QualifyLevelType == QualifyLevelType.Manual)
                            {
                                if (dialog != null)
                                {
                                    Common.Factory.Instance.GetApplicationServices().InvokeOnUiThread(
                                        () => { dialog?.CloseDialog(); });
                                }

                                NativeMethods.PlaySound(NativeMethods.SoundType.GOOD_SOUND);
                            }

                            continue;
                        }
                    }

                    consumableValidator.Validate(currentConsumableModel, patientContext?.CurrentPatient, BarcodeList, requiredConsumables);
                    UpdateConsumableDetails(currentConsumableModel);

                    var newConsumable = (BarcodeModel)currentConsumableModel.Clone();

                    if ((QualifyLevelType)newConsumable.QualifyLevelType == QualifyLevelType.Manual)
                        SaveBarcode(newConsumable, patientContext?.CurrentPatient?.Uuid.ToString());

                    UpdateConsumableList(newConsumable);
                    NativeMethods.PlaySound(NativeMethods.SoundType.GOOD_SOUND);
                }
            }
            catch (Exception ex)
            {
                NativeMethods.PlaySound(NativeMethods.SoundType.BAD_SOUND);
                var errorString = string.Empty;

                switch (ex)
                {
                    case InvalidDataException _:
                    case NotSupportedException _:
                    case CryptographicException _:
                        logger.Warning(Language.Error_InvalidConsumable);
                        errorString = Language.Error_InvalidConsumable + "\r\n";
                        break;
                    case InvalidConsumableException _:
                        if (ex.Message == Language.Error_ConsumableWithUnwantedCategory &&
                            ValidateAllRequiredConsumables(currentConsumableModel, allRequiredConsumables))
                        {
                            break;
                        }

                        var logMessage = new StringBuilder();
                        if (consumable?.Name != null && consumable?.Description != null)
                        {
                            logMessage.AppendLine($"{consumable.Name} ({consumable.Description}): {ex.Message}");
                        }
                        else
                        {
                            logMessage.AppendLine($"{ex.Message}");
                        }

                        logger.Warning(logMessage.ToString());
                        errorString = logMessage.ToString();
                        break;
                    default:
                        throw;
                }

                if (!string.IsNullOrEmpty(errorString))
                {
                    if (errorMessage.ContainsKey(smartSenseTag.Index))
                        errorMessage.Remove(smartSenseTag.Index);

                    errorMessage.Add(smartSenseTag.Index, errorString);
                }
            }
            finally
            {
                IsScanning = false;
            }

            IsBarCodeScanCompleted = IsAllScanCompleted();
        }

        public void WriteSmartSenseInformation()
        {
            var newConsumables = BarcodeList.Where(b => b.IsWritten == false).ToList();

            if (!newConsumables.Any()) return;

            foreach (var newConsumable in newConsumables)
            {
                if (newConsumable.QualifyLevelType == (int)QualifyLevelType.Manual)
                    continue;
                
                SaveBarcode(newConsumable, patientContext.CurrentPatient.Uuid.ToString());
            }

            var logMessage = GetLogMessage("WriteSmartSenseEvent", newConsumables);
            logger.Info(logMessage);
        }

        public string GetLogMessage(string methodName, IEnumerable<BarcodeModel> barcodeModels)
        {
            var logMessage = string.Empty;

            foreach (var barcodeModel in barcodeModels)
            {
                logMessage = logMessage + barcodeModel.ToString();
            }

            return methodName + ": \r\n" + logMessage;
        }

        public void RfidReaderTagErrorEvent(object sender, bool status)
        {
            if (status && dialog == null)
            {
                IsScanning = false;
                NativeMethods.PlaySound(NativeMethods.SoundType.BAD_SOUND);
                Common.Factory.Instance.GetApplicationServices().InvokeOnUiThread(
                    () =>
                    {
                        dialog = Common.UI.Factory.Instance.GetUserNotificationService()
                            .NotifyMessageModalessUserInfo(Language.Label_HoldPumpTubeError, UserReply.Cancel);
                        if (dialog != null)
                        {
                            dialog.Closing += (s, args) =>
                            {
                                if (RfidManager != null)
                                {
                                    RfidManager.CancelWriteOperation = true;
                                    RfidManager.TaskTagError = false;
                                }

                                dialog = null;
                            };
                        }
                    });
            }
            else if (!status)
            {
                if (dialog != null)
                {
                    Common.Factory.Instance.GetApplicationServices().InvokeOnUiThread(
                        () => { dialog?.CloseDialog(); });
                }
            }
        }

        public void RfidReaderScanningEvent(object sender, bool status)
        {
            IsScanning = status;
            if (status == true)
                NativeMethods.PlaySound(NativeMethods.SoundType.START_SOUND);
        }

        /// <summary>
        /// to initiate the Required Consumables and the Barcode List
        /// </summary>
        /// <param name="studyId">study Id</param>
        /// <param name="patientId">patient Id</param>
        /// <param name="patientUuid">patient Uuid</param>
        private void InitConsumables(int? studyId, int? patientId, string patientUuid)
        {
            errorMessage.Clear();
            RequiredConsumables = GetRequiredConsumables();

            // to get the barcodes used in the previous phase/s
            lock (DbAccessLock)
            {
                if (studyId != null)
                {
                    GetTestBarcodes(studyId.Value, patientUuid);
                }
            }

            IsBarCodeScanCompleted = IsAllScanCompleted();
        }

        /// <summary>
        /// to register an un-used barcode to the required Consumable list. one barcode may be registered on 
        /// multiple required Consumables according to the barcode's feature(category) list.
        /// If one of the barcode's categories matches more than 1 Required Consumables,
        ///   the single choice Required Consumable should be registered at first
        /// </summary>
        /// <param name="consumableModel">unused barcode</param>
        /// <param name="requiredConsumables">required Consumable list</param>
        private void RegisterBarcode(BarcodeModel consumableModel, IEnumerable<InvestigationConsumable> requiredConsumables)
        {
            lock (DbAccessLock)
            {
                if (consumableModel.TagId != null && !consumableModel.IsUsed && requiredConsumables != null)
                {
                    ConsumableType consumableType = consumableHelper.GetConsumableType(consumableModel);

                    var investigationConsumables = requiredConsumables.ToList();
                    if (BarcodeModel.IsGtinValid(consumableModel.GTIN))
                    {
                        // if already exists in database, get it; if not, save the new barcode.
                        var existingBarcode = BarcodeRepository.GetBarcode(
                            Convert.ToInt64(consumableModel.GTIN),
                            consumableModel.TagId);

                        if (existingBarcode == null)
                        {
                            if (investigationConsumables.Any(consumble =>
                                IsConsumableTypeMatched(consumble.RequiredCategory, consumableType) ==
                                QualifyType.Qualified))
                            {
                                NewConsumableCount++;
                            }
                        }
                    }

                    if (consumableType != null)
                    {
                        var supportedCategories =
                            InvestigationConsumable.GetSupportedCategories(consumableType, consumableModel.Color);
                        foreach (var supportedCategory in supportedCategories)
                        {
                            // match the single choice Required Consumable at first
                            var requiredConsumable = investigationConsumables.FirstOrDefault(x =>
                                !x.RequiredCategory.Exclusive && x.RequiredCategory.Category == supportedCategory &&
                                !x.IsScanned);

                            if (requiredConsumable == null)
                            {
                                // match the multiple choices Required Consumable 
                                requiredConsumable = investigationConsumables.FirstOrDefault(x =>
                                    x.RequiredCategory.Exclusive && x.RequiredCategory.Category == supportedCategory &&
                                    !x.IsScanned);
                            }

                            if (requiredConsumable != null)
                            {
                                requiredConsumable.ScannedBarcodeId = consumableModel.BarCodeId;
                                requiredConsumable.ScannedSerial = consumableModel.Serial ?? consumableModel.Lot;
                                requiredConsumable.TagId = consumableModel.TagId;
                                consumableModel.IsUsed = true;
                            }
                        }
                    }
                }
            }
        }

        private void UnregisterBarcode(BarcodeModel consumableModel, IEnumerable<InvestigationConsumable> requiredConsumables)
        {
            lock (DbAccessLock)
            {
                errorMessage.Remove(consumableModel.Index);
                if (consumableModel.IsUsed && requiredConsumables != null)
                {
                    ConsumableType consumableType = consumableHelper.GetConsumableType(consumableModel);

                    var investigationConsumables = requiredConsumables.ToList();
                    if (BarcodeModel.IsGtinValid(consumableModel.GTIN))
                    {
                        // if already exists in database, get it; if not, save the new barcode.
                        var existingBarcode = BarcodeRepository.GetBarcode(
                            Convert.ToInt64(consumableModel.GTIN),
                            consumableModel.TagId);

                        if (existingBarcode == null)
                        {
                            if (investigationConsumables.Any(consumble =>
                                IsConsumableTypeMatched(consumble.RequiredCategory, consumableType) ==
                                QualifyType.Qualified))
                            {
                                NewConsumableCount--;
                            }
                        }
                    }

                    if (consumableType != null)
                    {
                        IEnumerable<InvestigationConsumable> consumables =
                            investigationConsumables.Where(r => r.TagId != null);
                        foreach (var requiredConsumable in consumables)
                        {
                            if (requiredConsumable.ScannedBarcodeId == consumableModel.BarCodeId &&
                                consumableModel.TagId.SequenceEqual(requiredConsumable.TagId))
                            {
                                requiredConsumable.ScannedBarcodeId = 0;
                                requiredConsumable.ScannedSerial = string.Empty;
                                requiredConsumable.TagId = null;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// to find the alternative consumables for the required Channel-ConsumableCategory
        /// </summary>
        /// <param name="requiredConsumables">required Consumables list</param>
        /// <param name="requiredCategory">required Channel-ConsumableCategory</param>
        /// <returns>alternative consumables</returns>
        private IEnumerable<InvestigationConsumable> GetAlternativeConsumables(IEnumerable<InvestigationConsumable> requiredConsumables, ChannelConsumableCategory requiredCategory)
        {
            return requiredConsumables.Where(x => x.RequiredCategory.Exclusive
                                                  && x.RequiredCategory.InvestigationType == requiredCategory.InvestigationType
                                                  && x.RequiredCategory.ChannelType == requiredCategory.ChannelType
                                                  && x.RequiredCategory.Category != requiredCategory.Category);
        }

        /// <summary>
        /// to judge whether the consumable type have the qualified feature for the required category
        /// </summary>
        /// <param name="requiredCategory">required Channel-ConsumableCategory</param>
        /// <param name="consumableType">Consumable Type</param>
        /// <returns>true to indicate matched</returns>
        private QualifyType IsConsumableTypeMatched(ChannelConsumableCategory requiredCategory, ConsumableType consumableType)
        {
            var categories = InvestigationConsumable.GetSupportedCategories(consumableType);
            if (categories.Any(x => x.Equals(requiredCategory.Category)))
            {
                return requiredCategory.QualifyLevel;                
            }

            return QualifyType.Unknown;
        }

        private QualifyType IsConsumableTypeMatched(BarcodeModel consumableModel, ChannelConsumableCategory requiredCategory, ConsumableType consumableType)
        {
            var categories = InvestigationConsumable.GetSupportedCategories(consumableType, consumableModel.Color);
            if (categories.Any(x => x.Equals(requiredCategory.Category)))
            {
                return requiredCategory.QualifyLevel;
            }

            return QualifyType.Unknown;
        }

        private bool IsAllScanCompleted()
        {
            OnPropertyChanged(nameof(ErrorMessage));

            if (RequiredConsumables != null)
            {
                foreach (var consumable in RequiredConsumables)
                {
                    if (!consumable.IsScanned && consumable.IsQualified)
                    {
                        // this consumable or one of its alternative consumables should be scanned
                        var alternativeConsumables = GetAlternativeConsumables(RequiredConsumables, consumable.RequiredCategory);
                        if (alternativeConsumables == null || !alternativeConsumables.Any(x => x.IsScanned))
                            return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// to get the bitmap image of specified Consumable Type
        /// </summary>
        /// <param name="consumableType">Consumable Type</param>
        /// <returns>bitmap image</returns>
        private BitmapImage GetConsumableTypeImage(ConsumableType consumableType)
        {
            string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Consumables", consumableType.ImageFile);
            if (File.Exists(imagePath))
                return new BitmapImage(new Uri(imagePath));

            return null;
        }

        private IEnumerable<ChannelModel> GetRelevantChannelsForCurrentPreviewSequence()
        {
            if (Protocol?.PhaseModel == null || currentPreviewPhase == null)
                return new List<ChannelModel>();

            var channelCollection = new List<int>();
            var relevantPhases = Protocol.PhaseModel.Phases
                .Where(p => p.PhaseOrder >= currentPreviewPhase.PhaseOrder)
                .TakeWhile(p => p.Id == currentPreviewPhase.Id || p.PhaseType != PhaseModelTypes.PreviewPhase);

            foreach (var phase in relevantPhases)
            {
                var allVisibleChannels = phase.Descendants()
                    .SelectMany(p => new[] { p.VisibleChannels, p.ChannelValuesShownSeparately })
                    .SelectMany(channel => channel);

                channelCollection = channelCollection.Union(allVisibleChannels).ToList();
            }

            return Protocol.ChannelModels.Where(c => channelCollection.Contains(c.ChannelIndex));
        }

        private bool WriteSmartSenseTag(BarcodeModel barcodeModel, out byte[] data)
        {
            // Updates the SmartSense Tag
            bool isTagWritten = true;
            const int headerLength = 8;
            var logMessage = GetLogMessage("WriteSmartSenseTag", new List<BarcodeModel> { barcodeModel });

            data = smartSenseHelper.Encode(barcodeModel);

            switch ((QualifyLevelType)barcodeModel.QualifyLevelType)
            {
                case QualifyLevelType.Manual:
                    // Blocks Writing
                    var totalDataLength = BitConverter.ToUInt16(data.Take(2).ToArray(), 0);

                    var blockByteArray = data.Skip(headerLength).Take(totalDataLength).ToArray();
                    const int sizeOfAreaLengthInBytes = sizeof(ushort);

                    byte[] roAreaLentInBytes = blockByteArray.Take(sizeOfAreaLengthInBytes).ToArray();
                    int roAreaLength = (int)BitConverter.ToUInt16(roAreaLentInBytes, 0);
                    int offset = headerLength + (sizeOfAreaLengthInBytes * 2) + roAreaLength;

                    isTagWritten = RfidManager?.TryWriteToTag(offset, data) ?? false;
                    break;
                case QualifyLevelType.SmartSense:
                    if (PimService != null)
                    {
                        var tagId = BitConverter.ToUInt64(barcodeModel.TagId, 0);

                        var dataLength = data.Length - headerLength;
                        var newRfidTag = new RfidTag(tagId, barcodeModel.Index, data, (ushort)dataLength);
                        PimService.UpdateConsumer(newRfidTag);
                    }

                    break;
            }

            if (isTagWritten)
            {
                logger.Info(logMessage);
                barcodeModel.IsWritten = true;
            }
            
            return isTagWritten;
        }

        private IEnumerable<InvestigationConsumable> GetAllRequiredConsumables()
        {
            var consumables = new List<InvestigationConsumable>();

            if (Protocol?.PhaseModel == null || currentPreviewPhase == null)
                return consumables;

            var channelCollection = new List<int>();

            foreach (var phase in Protocol.PhaseModel.Phases)
            {
                var allVisibleChannels = phase.Descendants()
                    .SelectMany(p => new[] { p.VisibleChannels, p.ChannelValuesShownSeparately })
                    .SelectMany(channel => channel);

                channelCollection = channelCollection.Union(allVisibleChannels).ToList();
            }

            var channels = Protocol.ChannelModels.Where(c => channelCollection.Contains(c.ChannelIndex));

            foreach (var channel in channels)
            {
                var channelConsumableCategories = consumableHelper.GetChannelConsumableCategory(Protocol.InvestigationType, channel.ChannelType);

                consumables.AddRange(channelConsumableCategories.Select(category => new InvestigationConsumable()
                {
                    RequiredCategory = new ChannelConsumableCategory()
                    {
                        InvestigationType = category.InvestigationType,
                        ChannelType = category.ChannelType,
                        Category = category.Category,
                        QualifyLevel = category.QualifyLevel,
                        Exclusive = category.Exclusive
                    }
                }));
            }

            return consumables;
        }

        private bool ValidateAllRequiredConsumables(BarcodeModel consumableModel, IEnumerable<InvestigationConsumable> allRequiredConsumables)
        {
            var consumableType = consumableHelper.GetConsumableType(consumableModel);

            if (consumableType?.QualifyLevel == QualifyType.Qualified)
            {
                if (allRequiredConsumables != null)
                {
                    var notScannedConsumables = allRequiredConsumables.ToList();

                    if (requiredConsumables.Any())
                    {
                        notScannedConsumables = notScannedConsumables.Where(c =>
                            requiredConsumables.Any(r => !r.IsScanned && r.CategoryName == c.CategoryName)).ToList();
                    }

                    if (consumableModel.Color == (int)ColorEnums.Yellow && consumableType.PuraCatheter)
                    {
                        var puraConsumable = notScannedConsumables.FirstOrDefault(c =>
                            c.RequiredCategory.Category == ConsumableCategory.PuraCatheter);

                        return puraConsumable != null;
                    }
                    else
                    {
                        foreach (var consumable in notScannedConsumables)
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

                                var alternativeConsumables = notScannedConsumables.Where(x =>
                                    x.RequiredCategory.Exclusive
                                    && x.RequiredCategory.InvestigationType == requiredCategory.InvestigationType
                                    && x.RequiredCategory.ChannelType == requiredCategory.ChannelType
                                    && x.RequiredCategory.Category != requiredCategory.Category);

                                if (!alternativeConsumables.Any(x => x.IsScanned))
                                    return true;
                            }
                        }
                    }
                }
            }

            return false;
        }

        private void UpdateConsumableDetails(BarcodeModel consumableModel)
        {
            ConsumableType consumableType = consumableHelper.GetConsumableType(consumableModel);

            if (consumableType != null)
            {
                consumableModel.TypeName = consumableType.Name;
                consumableModel.Description = consumableType.Description;
                consumableModel.CategoryName = InvestigationConsumable.GetSupportedCategoryNames(consumableType, consumableModel.Color);
                consumableModel.DisplayImage = GetConsumableTypeImage(consumableType);
                consumableModel.QualifyLevel = (int)consumableType.QualifyLevel;
                consumableModel.QualifyLevelType = (int)consumableType.QualifyLevelType;
                if (patientContext?.CurrentPatient.Uuid != null)
                {
                    consumableModel.PatientGuid = patientContext?.CurrentPatient.Uuid.ToString();
                }
            }
        }

        private void DeleteConsumable(BarcodeModel consumableModel)
        {
            if (consumableModel == null) return;

            bool isTagWritten = true;
            var barcodeId = consumableModel.BarCodeId;
            Consumable barcode = BarcodeRepository?.GetBarcode(consumableModel.BarCodeId);

            if (barcode != null)
            {
                if (barcode.QualifyLevelType == (int)QualifyLevelType.Manual & dialog != null)
                    return;

                var gtin = barcode.Gtin ?? 0;
                IQueryable<Test> barcodeUsedInOtherTests = null;
                if (barcode.Gtin != null && barcode.Gtin != 0)
                {
                    barcodeUsedInOtherTests = BarcodeRepository?.GetBarcodeTests(gtin, barcode.TagId);
                }

                if (barcodeUsedInOtherTests == null || !barcodeUsedInOtherTests.Any())
                {
                    if (consumableModel.EncryptedBytes != null)
                    {
                        consumableModel.UsedDate = null;
                        consumableModel.PatientGuid = string.Empty;
                        consumableModel.PatientIdCrc = null;
                        isTagWritten = WriteSmartSenseTag(consumableModel, out _);
                    }

                    if (isTagWritten)
                    {
                        lock (DbAccessLock)
                        {
                            barcode = BarcodeRepository?.GetBarcode(barcodeId);

                            if (barcode != null)
                            {
                                BarcodeRepository?.DeleteBarcode(barcode);
                                BarcodeList = barcodeList.Where(b => b.BarCodeId != barcodeId).ToList();
                                UnregisterBarcode(consumableModel, requiredConsumables);
                                IsBarCodeScanCompleted = IsAllScanCompleted();
                            }
                        }
                    }

                    return;
                }
            }

            BarcodeList = barcodeList.Where(b => b.Index != consumableModel.Index).ToList();
            UnregisterBarcode(consumableModel, requiredConsumables);
            IsBarCodeScanCompleted = IsAllScanCompleted();
        }
    }
}
