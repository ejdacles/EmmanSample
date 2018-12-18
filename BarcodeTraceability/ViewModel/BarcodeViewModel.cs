// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Laborie">
//   Copyright (c) Laborie. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Laborie.Synergy.BarcodeTraceability.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Globalization;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Threading;
    using Common;
    using Common.ApplicationLogging;
    using Common.DateFormat;
    using Common.UI.Models;
    using Exceptions;
    using HardwareManager.Interfaces;
    using Laborie.Synergy.Common.Services;
    using Model;
    using PatientManager;
    using RfidReader;
    using Translations;

    /// <summary>
    /// Barcode ViewModel Class
    /// </summary>
    public class BarcodeViewModel : BindableBase, IDisposable
    {
        private readonly ILogger logger = Common.Factory.Instance.CreateApplicationLogger(typeof(BarcodeViewModel));
        private readonly IPatientManager patientManager;
        private bool disposed = false;
        private string errorMessage = string.Empty;
        private Visibility showArbitrary = Visibility.Collapsed;
        private string arbitraryErrorMessage = string.Empty;
        private string buttonDisabledReason = string.Empty;
        
        private Visibility isBypassVisible = Visibility.Hidden;
        
        private string arbitraryExpiryDate;
        private string arbitraryName;
        private string arbitraryType;
        private string arbitraryLot;
        private string arbitrarySerial;

        /// <summary>
        /// Initializes a new instance of the <see cref="BarcodeViewModel"/> class.
        /// </summary>
        /// <param name="patientManager">Patient manager object</param>
        /// <param name="barcodeTraceabilityManager">Barcode traceability manager</param>
        public BarcodeViewModel(IPatientManager patientManager, IBarcodeTraceabilityManager barcodeTraceabilityManager)
        {
            this.patientManager = patientManager;
            BarcodeTraceabilityManager = barcodeTraceabilityManager;
            SaveArbitraryCommand = new RelayCommand(OnSaveArbitraryCommand);

            Barcode = new BarcodeModel() { ProductionDate = null, ExpiryDate = new DateTime() };
            ArbitraryBarcode = new BarcodeModel()
            {
                QualifyLevel = (int)QualifyType.Unknown,
                QualifyLevelType = (int)QualifyLevelType.Other,
                ProductionDate = null,
                ExpiryDate = null
            };

            patientManager.PatientContext.PropertyChanged += OnDependentPropertyChanged;

            barcodeTraceabilityManager.PropertyChanged += OnDependentPropertyChanged;
            barcodeTraceabilityManager.IsBypassUsed = false;
            barcodeTraceabilityManager.IsScanning = false;
            barcodeTraceabilityManager.NewConsumableCount = 0;

            SaveCommand = new RelayCommand(OnSaveCommand);
            AddArbitraryCommand = new RelayCommand(OnAddArbitraryCommand);
            
            BypassCommand = new RelayCommand(OnBypassCommand);
            RemoveBarcodeCommand = new RelayCommand<int>(OnRemoveBarcodeCommand);
        }

        public string DateFormatAsPerLocalCulture => CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;

        /// <summary>
        /// Gets or sets Barcode Model
        /// </summary>
        public BarcodeModel Barcode { get; set; }

        /// <summary>
        /// Gets or sets Arbitrary Barcode Model
        /// </summary>
        public BarcodeModel ArbitraryBarcode { get; set; }

        /// <summary>
        /// Gets or sets Arbitrary Name
        /// </summary>
        public string ArbitraryName
        {
            get => arbitraryName;
            set
            {
                ArbitraryBarcode.CategoryName = value;
                SetProperty(ref arbitraryName, value);
                ArbitraryErrorMessage = string.Empty;
            } 
        }

        /// <summary>
        /// Gets or sets Arbitrary Type
        /// </summary>
        public string ArbitraryType
        {
            get => arbitraryType;
            set
            {
                ArbitraryBarcode.TypeName = value;
                SetProperty(ref arbitraryType, value);
                ArbitraryErrorMessage = string.Empty;
            } 
        }

        /// <summary>
        /// Gets or sets Arbitrary Lot
        /// </summary>
        public string ArbitraryLot
        {
            get => arbitraryLot;
            set
            {
                ArbitraryBarcode.Lot = value;
                SetProperty(ref arbitraryLot, value);
                ArbitraryErrorMessage = string.Empty;
            }
        }

        /// <summary>
        /// Gets or sets Arbitrary Serial 
        /// </summary>
        public string ArbitrarySerial
        {
            get => arbitrarySerial;
            set
            {
                ArbitraryBarcode.Serial = value;
                SetProperty(ref arbitrarySerial, value);
                ArbitraryErrorMessage = string.Empty;
            } 
        }

        /// <summary>
        /// Gets or sets Arbitrary Expiry Date
        /// </summary>
        public string ArbitraryExpiryDate
        {
            get => arbitraryExpiryDate;
            set
            {
                SetProperty(ref arbitraryExpiryDate, value);
                ArbitraryErrorMessage = string.Empty;
            }
        }
        
        /// <summary>
        /// Gets or sets error message
        /// </summary>
        public string ErrorMessage
        {
            get => errorMessage;

            set => SetProperty(ref errorMessage, value);
        }

        /// <summary>
        /// Gets or sets error message
        /// </summary>
        public string ArbitraryErrorMessage
        {
            get => arbitraryErrorMessage;

            set => SetProperty(ref arbitraryErrorMessage, value);
        }

        /// <summary>
        /// Gets or sets if arbitrary will be shown
        /// </summary>
        public Visibility ShowArbitrary
        {
            get => showArbitrary;

            set
            {
                SetProperty(ref showArbitrary, value);
                OnPropertyChanged(nameof(ShowArbitrary));
            }
        }

        /// <summary>
        /// Gets required Consumables
        /// </summary>
        public IEnumerable<InvestigationConsumable> RequiredConsumables
        {
            get
            {
                IEnumerable<InvestigationConsumable> requiredConsumables =
                    BarcodeTraceabilityManager.RequiredConsumables.Where(r => r.IsQualified || r.IsScanned);

                IsBypassVisible = requiredConsumables.Any() ? Visibility.Visible : Visibility.Hidden;
                
                return requiredConsumables;
            }
        }

        /// <summary>
        /// Gets Barcode list
        /// </summary>
        public IEnumerable<BarcodeModel> BarcodeList => BarcodeTraceabilityManager.BarcodeList.OrderBy(b => b.QualifyLevelType);

        /// <summary>
        /// Gets a value indicating whether Patient is selected
        /// </summary>
        public bool IsPatientSelected => (patientManager.PatientContext as PatientContext)?.CurrentPatient != null ? Convert.ToInt32((patientManager.PatientContext as PatientContext)?.CurrentPatient.DbId) > 0 : false;

        /// <summary>
        /// Gets or sets the Save Command
        /// </summary>
        public RelayCommand SaveCommand { get; set; }

        /// <summary>
        /// Gets or sets the Add Arbitrary Command
        /// </summary>
        public RelayCommand AddArbitraryCommand { get; set; }

        /// <summary>
        /// Gets or sets the Save Arbitrary Command
        /// </summary>
        public RelayCommand SaveArbitraryCommand { get; set; }

        /// <summary>
        /// Gets or sets the RemoveBarcode Command
        /// </summary>
        public RelayCommand<int> RemoveBarcodeCommand { get; set; }

        /// <summary>
        /// Gets or sets the Bypass Command
        /// </summary>
        public RelayCommand BypassCommand { get; set; }

        /// <summary>
        /// Gets or sets the BarcodeId
        /// </summary>
        public int BarcodeId { get; set; }

        /// <summary>
        /// Gets a value indicating whether the Bypass button is enabled
        /// </summary>
        public bool IsEnabledBypass
        {
            get
            {
                bool enabled = BarcodeTraceabilityManager.BypassCount > 0 &&
                               !BarcodeTraceabilityManager.IsBypassUsed &&
                               !BarcodeTraceabilityManager.IsBarCodeScanCompleted;
                if (!enabled)
                    ButtonDisabledReason = BarcodeTraceabilityManager.IsBarCodeScanCompleted ? Language.Tooltip_ConsumablesRegistered : Language.Tooltip_NoMoreBypass;

                return enabled;
            }
        }

        /// <summary>
        /// Gets or sets tool tip 
        /// </summary>
        public string ButtonDisabledReason
        {
            get
            {
                return buttonDisabledReason;
            }

            set
            {
                SetProperty(ref buttonDisabledReason, value);
            }
        }

        public Visibility IsBypassVisible
        {
            get
            {
                if (RequiredConsumables.Any())
                {
                    return Visibility.Visible;
                }

                return Visibility.Hidden;
            }

            set
            {
                SetProperty(ref isBypassVisible, value);
            }
        }

        /// <summary>
        /// Gets a value indicating whether to display the Bypass message
        /// </summary>
        public bool DisplayBypassMessage => BarcodeTraceabilityManager.IsBypassUsed;

        /// <summary>
        /// Gets a value indicating whether to display the Bypass message
        /// </summary>
        public bool DisplayScanningMessage => BarcodeTraceabilityManager.IsScanning;

        /// <summary>
        /// Gets a value indicating whether gets the Remove button IsEnabled status
        /// </summary>
        public bool IsEnabledRemoveBarcode => !BarcodeTraceabilityManager.RecordStarted;

        /// <summary>
        /// Gets the Bypass button Content
        /// </summary>
        public string BypassText => $"{Language.Action_Bypass} ({BarcodeTraceabilityManager.BypassCount})";

        /// <summary>
        /// Gets the barcode traceability manager
        /// </summary>
        public IBarcodeTraceabilityManager BarcodeTraceabilityManager { get; }

        public string ConsumableErrorMessage => BarcodeTraceabilityManager.ErrorMessage;

        public Visibility ErrorMessageVisibility
        {
            get
            {
                if (ConsumableErrorMessage != string.Empty)
                {
                    return Visibility.Visible;
                }

                return Visibility.Collapsed;
            }
        }

        /// <summary>
        /// Dispose of Object
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void RfidReader_rfidEvent(object sender, RfidManager.ParsedGS1EventArgs e)
        {
            Dictionary<EAN128Parser.AII, string> result = e.Result;

            CultureInfo current = CultureInfo.CurrentCulture;
            DateTimeFormatInfo dtfi = (DateTimeFormatInfo)current.DateTimeFormat.Clone();
            dtfi.Calendar = (System.Globalization.Calendar)dtfi.Calendar.Clone();
            dtfi.Calendar.TwoDigitYearMax = 2099;

            // Future: Decouple from ViewModel and move to a Business Model.
            foreach (KeyValuePair<EAN128Parser.AII, string> gs1Barcode in result)
            {
                switch (gs1Barcode.Key.AI)
                {
                    case "01":
                        Barcode.GTIN = gs1Barcode.Value;
                        break;
                    case "11":
                        Barcode.ProductionDate = DateTime.ParseExact(gs1Barcode.Value, "yyMMdd", dtfi);
                        break;
                    case "17":
                        Barcode.ExpiryDate = DateTime.ParseExact(gs1Barcode.Value, "yyMMdd", dtfi);
                        break;
                    case "10":
                        Barcode.Lot = gs1Barcode.Value;
                        break;
                    case "21":
                        Barcode.Serial = gs1Barcode.Value;
                        break;
                    default:
                        break;
                }
            }

            if (result.Count != 0)
            {
                Dispatcher dispatchObject = Application.Current?.Dispatcher;
                if (dispatchObject == null || dispatchObject.CheckAccess())
                {
                    OnSaveCommand();
                }
                else
                {
                    // Dispatch on UI Thread
                    dispatchObject.BeginInvoke((Action)OnSaveCommand);
                }
            }
        }

        /// <summary>
        /// Dispose the object.
        /// </summary>
        /// <param name="disposing">Indicates disposing is active.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            disposed = true;
        }
        
        /// <summary>
        /// Save Barcode info to the database
        /// </summary>
        private void OnSaveCommand()
        {
            try
            {
                BarcodeTraceabilityManager.ValidateBarcode(
                    patientManager.PatientContext.CurrentPatient.DbId,
                    patientManager.PatientContext.CurrentPatient.Uuid.ToString(),
                    Barcode);

                BarcodeModel newBarCode = (BarcodeModel)Barcode.Clone();
                BarcodeId = BarcodeTraceabilityManager.SaveBarcode(newBarCode, patientManager.PatientContext.CurrentPatient.Uuid.ToString());
                BarcodeTraceabilityManager.UpdateConsumableList(newBarCode);
                OnPropertyChanged(nameof(BarcodeList));
                ErrorMessage = string.Empty;
            }
            catch (ConsumableIsUsedByOtherPatientException ex)
            {
                ErrorMessage = ex.Message;
                logger.Error("Error validating consumable in BarcodeViewModel -> OnSaveCommand " + ex.Message);
            }
            catch (ConsumableTimeLimitExpiredException ex)
            {
                ErrorMessage = ex.Message;
                logger.Error("Error validating consumable in BarcodeViewModel -> OnSaveCommand " + ex.Message);
            }
            catch (ConsumableWithDuplicateBarcodeExistsException ex)
            {
                ErrorMessage = ex.Message;
                logger.Error("Error validating consumable in BarcodeViewModel -> OnSaveCommand " + ex.Message);
            }
            catch (InvalidConsumableException ex)
            {
                ErrorMessage = ex.Message;
                logger.Error("Error validating consumable in BarcodeViewModel -> OnSaveCommand " + ex.Message);
            }
            catch (OverflowException ex)
            {
                ErrorMessage = Language.Error_OverflowException;
                logger.Error("Error validating consumable in BarcodeViewModel -> OnSaveCommand " + ex.Message);
            }
        }

        /// <summary>
        /// Open or close the Arbitrary Groupbox
        /// </summary>
        private void OnAddArbitraryCommand()
        {
            ArbitraryBarcode = new BarcodeModel()
            {
                QualifyLevel = 0,
                ProductionDate = null,
                ExpiryDate = null,
                QualifyLevelType = (int)QualifyLevelType.Other
            };

            ArbitraryName = string.Empty;
            ArbitraryType = string.Empty;
            ArbitraryLot = string.Empty;
            ArbitrarySerial = string.Empty;
            ArbitraryExpiryDate = string.Empty;

            ShowArbitrary = ShowArbitrary == Visibility.Collapsed ? Visibility.Visible : Visibility.Collapsed;
        }

        /// <summary>
        /// Save Arbitrary Barcode info to the database
        /// </summary>
        private void OnSaveArbitraryCommand()
        {
            if (ArbitraryBarcode != null)
            {
                if (!ValidateArbitrary())
                {
                    return;
                }

                BarcodeModel newBarCode = (BarcodeModel)ArbitraryBarcode.Clone();
                BarcodeId = BarcodeTraceabilityManager.SaveBarcode(
                    newBarCode, patientManager.PatientContext.CurrentPatient.Uuid.ToString());
                BarcodeTraceabilityManager.UpdateConsumableList(newBarCode);
            }

            OnAddArbitraryCommand();
            OnPropertyChanged(nameof(BarcodeList));
        }

        /// <summary>
        /// Removes the barcode from the scanned barcode list
        /// </summary>
        /// <param name="barCodeId">barCode Id</param>
        private void OnRemoveBarcodeCommand(int barCodeId)
        {
            Task.Run(() =>
            {
                BarcodeTraceabilityManager.RemoveBarcode(barCodeId);

                Common.Factory.Instance.GetApplicationServices().InvokeOnUiThread(
                    () =>
                    {
                        OnPropertyChanged(nameof(RequiredConsumables));
                        OnPropertyChanged(nameof(BarcodeList));
                    });
            });
        }

        /// <summary>
        /// Bypass the Barcode scanning
        /// </summary>
        private void OnBypassCommand()
        {
            BarcodeTraceabilityManager.UseBypass();
            ErrorMessage = string.Empty;
        }

        /// <summary>
        /// Raise property changed when dependent property has changed
        /// </summary>
        /// <param name="sender">Instance that is invoking this method</param>
        /// <param name="e">The dependent property that has been changed</param>
        private void OnDependentPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(PatientContext.CurrentPatient):
                    OnPropertyChanged(nameof(IsPatientSelected));
                    break;
                case nameof(BarcodeTraceabilityManager.RecordStarted):
                    OnPropertyChanged(nameof(IsEnabledRemoveBarcode));
                    break;
                case nameof(BarcodeTraceabilityManager.IsBypassUsed):
                    OnPropertyChanged(nameof(BypassText));
                    OnPropertyChanged(nameof(IsEnabledBypass));
                    OnPropertyChanged(nameof(DisplayBypassMessage));
                    break;
                case nameof(BarcodeTraceabilityManager.RequiredConsumables):
                    OnPropertyChanged(nameof(RequiredConsumables));
                    break;
                case nameof(BarcodeTraceabilityManager.BarcodeList):
                    OnPropertyChanged(nameof(BarcodeList));
                    break;
                case nameof(BarcodeTraceabilityManager.IsBarCodeScanCompleted):
                    OnPropertyChanged(nameof(IsEnabledBypass));
                    break;
                case nameof(BarcodeTraceabilityManager.ErrorMessage):
                    OnPropertyChanged(nameof(ConsumableErrorMessage));
                    OnPropertyChanged(nameof(ErrorMessageVisibility));
                    break;
                case nameof(BarcodeTraceabilityManager.IsScanning):
                    OnPropertyChanged(nameof(DisplayScanningMessage));
                    break;
                default:
                    break;
            }
        }

        private bool ValidateArbitrary()
        {
            bool valid = true;
            ArbitraryErrorMessage = string.Empty;

            switch (ValidateExpireDate(ArbitraryExpiryDate))
            {
                case ExpireDateState.Valid:
                    var interpretedDate = DateInterpreter.InterpretDateText(ArbitraryExpiryDate);
                    var correctedDate = DateInterpreter.ReformatAndValidateDate(interpretedDate);
                    ArbitraryBarcode.ExpiryDate = DateFormat.ParseExact(correctedDate);
                    break;
                case ExpireDateState.Expired:
                    valid = false;
                    ArbitraryErrorMessage = Language.Error_ConsumableExpired;
                    break;
                case ExpireDateState.Invalid:
                    valid = false;
                    ArbitraryErrorMessage = Language.Error_InvalidExpiryDate;
                    break;
            }

            return valid;
        }

        private ExpireDateState ValidateExpireDate(string value)
        {
            ExpireDateState state = ExpireDateState.Valid;

            if (string.IsNullOrEmpty((string)value))
                return ExpireDateState.Empty;

            var datePattern = DateFormat.SynergyCultureInfo.DateTimeFormat.ShortDatePattern; 
            var parts = value.Split(DateFormat.DateSeparators(datePattern));

            if (parts.Length != 3)
            {
                // treat as invalid as not all of day/month/year entered
                return ExpireDateState.Invalid;
            }

            if (!DateTime.TryParseExact((string)value, DateFormat.SynergyCultureInfo.DateTimeFormat.ShortDatePattern, DateFormat.SynergyCultureInfo, DateTimeStyles.None, out DateTime dateTime))
            {
                return ExpireDateState.Invalid;
            }

            if (dateTime.Date < DateTime.Now.Date)
            {
                return ExpireDateState.Expired;
            }

            return state;
        }
    }
}
