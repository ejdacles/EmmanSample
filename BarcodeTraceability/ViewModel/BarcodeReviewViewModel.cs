// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Laborie">
//   Copyright (c) Laborie. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Laborie.Synergy.BarcodeTraceability.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Media.Imaging;
    using Common;
    using Model;
    using PatientManager;

    /// <summary>
    /// Initializes a new instance of the <see cref="BarcodeReviewViewModel"/> class.
    /// </summary>
    public class BarcodeReviewViewModel : BindableBase
    {
        private BarcodeModel currentBarcodeModel;
        private IPatientManager patientManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="BarcodeReviewViewModel"/> class.
        /// </summary>
        /// <param name="patientManager">Patient Manager</param>
        /// <param name="barcodeTraceabilityManager">Barcode Traceability Manager</param>
        public BarcodeReviewViewModel(IPatientManager patientManager, BarcodeTraceabilityManager barcodeTraceabilityManager)
        {
            BarcodeTraceabilityManager = barcodeTraceabilityManager;
            barcodeTraceabilityManager.InitReviewConsumables(patientManager.PatientContext.CurrentStudy.ID, patientManager.PatientContext.CurrentPatient.Uuid.ToString());
            this.patientManager = patientManager;
        }

        /// <summary>
        /// Gets Barcode list
        /// </summary>
        public IEnumerable<BarcodeModel> BarcodeReviewModelList => BarcodeTraceabilityManager.BarcodeReviewList.OrderBy(b => b.QualifyLevelType);

        /// <summary>
        /// Gets or sets the Current BarcodeModel 
        /// </summary>
        public BarcodeModel CurrentBarcodeModel
        {
            get
            {
                return currentBarcodeModel;
            }

            set
            {
                SetProperty(ref currentBarcodeModel, value);
                OnPropertyChanged(nameof(DisplayImage));
            }
        }

        /// <summary>
        /// Gets  the Display Image
        /// </summary>
        public BitmapImage DisplayImage => CurrentBarcodeModel?.DisplayImage;

        /// <summary>
        /// Gets gets or sets Required Consumables
        /// </summary>
        public IEnumerable<InvestigationConsumable> RequiredConsumables
        {
            get
            {
                return BarcodeTraceabilityManager.RequiredConsumables.Where(r => r.IsQualified || r.IsScanned);
            }
        }

        /// <summary>
        /// Gets the barcode traceability manager
        /// </summary>
        public BarcodeTraceabilityManager BarcodeTraceabilityManager { get; }

        /// <summary>
        /// Gets a value indicating whether gets the Bypass button IsEnabled status
        /// </summary>
        public bool IsEnabledBypass => BarcodeTraceabilityManager.BypassCount > 0 && !BarcodeTraceabilityManager.IsBypassUsed;

        /// <summary>
        /// Gets a value indicating whether to display the Bypass message
        /// </summary>
        public bool DisplayBypassMessage => BarcodeTraceabilityManager.IsBypassUsed;

        /// <summary>
        /// Makes a call to retrieve all barcodes for the patient, which will trigger Audit Log entry to be created.
        /// </summary>
        /// <param name="sender">Object sender</param>
        /// <param name="args">Event arguments</param>
        public void CreateAuditLogEntry(object sender, EventArgs args)
        {
            BarcodeTraceabilityManager.BarcodeRepository.GetPatientTestBarcodes(
                patientManager.PatientContext.CurrentStudy.ID,
                patientManager.PatientContext.CurrentPatient.Uuid.ToString());
        }
    }
}
