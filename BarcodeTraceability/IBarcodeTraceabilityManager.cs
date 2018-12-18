// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Laborie">
//   Copyright (c) Laborie. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Laborie.Synergy.BarcodeTraceability
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Laborie.Synergy.DataModel;
    using Laborie.Synergy.HardwareManager.Interfaces;
    using Laborie.Synergy.RfidReader;
    using Model;

    /// <summary>
    /// Interface for the barcode traceability manager
    /// </summary>
    public interface IBarcodeTraceabilityManager
    {
        /// <summary>
        /// Notifies observers of changing properties
        /// </summary>
        event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets or sets the RfidManager Instance
        /// </summary>
        RfidManager RfidManager { get; set; }

        /// <summary>
        /// Gets a value indicating whether Barcode scan is completed.
        /// </summary>
        bool IsBarCodeScanCompleted { get; }

        /// <summary>
        /// Gets or sets a value indicating whether the recording is started.
        /// </summary>
        bool RecordStarted { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the Bypass is used for current procedure
        /// </summary>
        bool IsBypassUsed { get; set; }

        bool IsScanning { get; set; }

        int NewConsumableCount { get; set; }

        /// <summary>
        /// Gets the Required Consumables
        /// </summary>
        IEnumerable<InvestigationConsumable> RequiredConsumables { get; }

        /// <summary>
        /// Gets the Barcode list
        /// </summary>
        IEnumerable<BarcodeModel> BarcodeList { get; }

        IEnumerable<BarcodeModel> BarcodeReviewList { get; }

        /// <summary>
        /// Gets current Bypass Count from license
        /// </summary>
        int BypassCount { get; }

        string ErrorMessage { get; }

        IRfidInventory RfidInventory { get; set; }

        IPimService PimService { get; set; }

        /// <summary>
        /// Invoked externally at the start of a phase
        /// </summary>
        /// <param name="currentPhase">The phase currently being executed</param>
        void OnPhaseStart(PhaseModel currentPhase);

        /// <summary>
        /// Invoked externally at the end of the procedure
        /// </summary>
        void OnProcedureEnd();

        /// <summary>
        /// Save the barcode to the database
        /// </summary>
        /// <param name="barcode">barcode model</param>
        /// <param name="patientUuid">UUID of current patient</param>
        /// <returns>Database id of the new generated barcode</returns>
        int SaveBarcode(BarcodeModel barcode, string patientUuid);

        /// <summary>
        /// remove the barcode from barcode List
        /// </summary>
        /// <param name="barcodeId">barCode Id</param>
        void RemoveBarcode(int barcodeId);

        /// <summary>
        /// Validate the barcode information
        /// </summary>
        /// <param name="currentPatientDbId">Patient database id</param>
        /// <param name="currentPatientGuid">patient ID</param>
        /// <param name="barcode">barcode model</param>
        void ValidateBarcode(int currentPatientDbId, string currentPatientGuid, BarcodeModel barcode);

        /// <summary>
        /// Validate the arbitrary consumable information
        /// </summary>
        /// <param name="currentPatientDbId">Patient database id</param>
        /// <param name="barcode">barcode model</param>
        void ValidateArbitraryBarcode(int currentPatientDbId, BarcodeModel barcode);

        /// <summary>
        /// use the Consumable Bypass, decrease the Bypass count in license
        /// </summary>
        void UseBypass();

        void UpdateSmartSenseInventory(IRfidInventory rfidInventory);

        void WriteSmartSenseInformation();

        string GetLogMessage(string methodName, IEnumerable<BarcodeModel> barcodeModels);

        void PimServiceOnInventoryScanDone(object sender, IRfidInventoryUpdate rfidInventoryUpdate);

        void PimServiceOnConsumerChanged(object sender, IRfidTagUpdate rfidTagUpdate);

        void PimServiceOnServiceDataReceived(object sender, ISmartSenseTag smartSenseTag);

        void UpdateConsumableList(BarcodeModel consumableModel);

        void RfidReaderTagErrorEvent(object sender, bool status);

        void RfidReaderScanningEvent(object sender, bool status);
    }
}