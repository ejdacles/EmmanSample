// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Laborie">
//   Copyright (c) Laborie. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Laborie.Synergy.BarcodeTraceability
{
    using Common;
    using Common.Services;
    using DataModel;
    using DataStorage.Interfaces;
    using Laborie.Synergy.BarcodeTraceability.SmartSense;
    using ProcedureManager.Interfaces;
    using ViewModel;
    using Views;

    /// <summary>
    /// The factory of the Barcode. Creates all instances and handles the dependency injection.
    /// </summary>
    public class Factory
    {
        private BarcodeTraceabilityManager barcodeTraceabilityManager;
        private ConsumableMatrixHelper consumableMatrixHelper;

        /// <summary>
        /// Gets the instance of the Factory (Singleton pattern).
        /// </summary>
        public static Factory Instance { get; internal set; } = new Factory();

        /// <summary>
        /// Get barcode traceability manager.
        /// </summary>
        /// <param name="protocol">The Protocol Model</param>
        /// <param name="consumableBarcodeManager">The Consumable Barcode Manager</param>
        /// <returns>The barcode traceability manager.</returns>
        public virtual IBarcodeTraceabilityManager GetBarcodeTraceabilityManager(ProtocolModel protocol, IConsumableBarcodeManager consumableBarcodeManager)
        {
            if (barcodeTraceabilityManager == null)
            {
                barcodeTraceabilityManager = new BarcodeTraceabilityManager(DataStorage.Factory.Instance.CreateUnitOfWork(UseCaseNames.WorkflowExecution).BarcodeRepository, protocol, consumableBarcodeManager);
            }
            else
            {
                barcodeTraceabilityManager.Protocol = protocol;
                barcodeTraceabilityManager.ConsumableBarcodeManager = consumableBarcodeManager;
            }

            return barcodeTraceabilityManager;
        }

        public virtual IBarcodeTraceabilityManager GetBarcodeTraceabilityManager() => barcodeTraceabilityManager;

        /// <summary>
        /// Create a questionnaire manager with the given UnitOfWork
        /// </summary>
        /// <param name="unitOfWork">The UoW which will be used by the new questionnaire manager</param>
        /// <returns>A new instance of a QuestionnaireManager</returns>
        public virtual BarcodeTraceabilityManager CreateBarcodeTraceabilityManager(IUnitOfWork unitOfWork)
        {
            return new BarcodeTraceabilityManager(unitOfWork);
        }
        
        /// <summary>
        /// get Consumable Matrix Helper
        /// </summary>
        /// <returns>Consumable Matrix Helper</returns>
        public virtual ConsumableMatrixHelper GetConsumableMatrixHelper()
        {
            if (consumableMatrixHelper == null)
            {
                consumableMatrixHelper = new ConsumableMatrixHelper(
                    DataStorage.Factory.Instance.CreateUnitOfWork(UseCaseNames.WorkflowExecution).
                        BarcodeRepository, new FileWrapper());
            }

            return consumableMatrixHelper;
        }

        /// <summary>
        /// Creates the Barcode and its view model.
        /// </summary>
        /// <param name="protocol">The Protocol Model</param>
        /// <param name="consumableBarcodeManager">The Consumable Barcode Manager</param>
        /// <returns>The <see cref="MvvmSet"/>.</returns>
        public virtual MvvmSet<BarcodeView, BarcodeViewModel> CreateBarcodeMvvmSet(ProtocolModel protocol, IConsumableBarcodeManager consumableBarcodeManager)
        {
            BarcodeViewModel barcodeViewModel = new BarcodeViewModel(PatientManager.Factory.Instance.GetPatientManager(), GetBarcodeTraceabilityManager(protocol, consumableBarcodeManager));

            return new MvvmSet<BarcodeView, BarcodeViewModel>(new BarcodeView(), barcodeViewModel);
        }

        /// <summary>
        /// Creates the TestBarcodeView and its view model.
        /// </summary>
        /// <param name="protocol">The Protocol Model</param>
        /// <param name="consumableBarcodeManager">The Consumable Barcode Manager</param>
        /// <returns>The <see cref="MvvmSet"/>.</returns>
        public virtual MvvmSet<BarcodeReviewView, BarcodeReviewViewModel> CreateBarcodeReviewMvvmSet(ProtocolModel protocol, IConsumableBarcodeManager consumableBarcodeManager)
        {            
            var barcode = (BarcodeTraceabilityManager)GetBarcodeTraceabilityManager(protocol, consumableBarcodeManager);

            BarcodeReviewViewModel barcodeReviewViewModel = new BarcodeReviewViewModel(PatientManager.Factory.Instance.GetPatientManager(), barcode);
                
            return new MvvmSet<BarcodeReviewView, BarcodeReviewViewModel>(new BarcodeReviewView(), barcodeReviewViewModel);
        }
    }
}
