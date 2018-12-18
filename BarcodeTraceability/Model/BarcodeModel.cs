// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Laborie">
//   Copyright (c) Laborie. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Laborie.Synergy.BarcodeTraceability.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Windows.Media.Imaging;
    using Common;
    using Translations;

    /// <summary>
    /// Barcode Model
    /// </summary>
    public class BarcodeModel : BindableBase, ICloneable, IEqualityComparer<BarcodeModel>
    {
        private const int Gtin14Length = 14;

        private int barCodeId;
        private string gtin;
        private DateTime? productionDate;
        private DateTime? expiryDate;
        private string lot;
        private string serial;
        private string categoryName;
        private string typeName;
        private string description;
        private int qualifyLevel;
        private int qualifyLevelType;
        private byte[] tagId;
        private string patientGuid;
        private DateTime? usedDate;
        private byte[] encryptedBytes;

        /// <summary>
        /// Gets or sets Laborie Company Code of GTIN
        /// </summary>
        public static string LaborieCompanyCode { get; set; }

        /// <summary>
        /// Gets or sets the supported Company Codes
        /// </summary>
        public static List<string> SupportedCompanyCodes { get; set; }

        /// <summary>
        /// Gets or sets the BarCodeId
        /// </summary>
        [Display(AutoGenerateField = false)]
        public int BarCodeId
        {
            get => barCodeId;

            set => SetProperty(ref barCodeId, value);
        }

        /// <summary>
        /// Gets or sets the BarCodeId
        /// </summary>
        [Display(AutoGenerateField = false)]
        public int QualifyLevel
        {
            get => qualifyLevel;

            set => SetProperty(ref qualifyLevel, value);
        }

        /// <summary>
        /// Gets or sets the BarCodeId
        /// </summary>
        [Display(AutoGenerateField = false)]
        public int QualifyLevelType
        {
            get => qualifyLevelType;

            set => SetProperty(ref qualifyLevelType, value);
        }

        /// <summary>
        /// Gets or sets the GTIN number
        ///    GTIN Digits 0~1 : package code, 00 - Pouch; 10 - Box; 20 - Case
        ///    GTIN Digits 2~7 : company code, fixed as "627825" for LABORIE
        ///    GTIN Digits 8~12 : item number
        ///    GTIN Digits 13 : CRC code
        /// </summary>
        [Display(AutoGenerateField = false)]
        public string GTIN
        {
            get => gtin;

            set
            {
                gtin = value;
                if (gtin.Length < Gtin14Length)
                {
                    gtin = gtin.PadLeft(Gtin14Length, '0');
                }

                OnPropertyChanged(nameof(GTIN));
            }
        }

        /// <summary>
        /// Gets or sets CategoryName
        /// </summary>
        [Display(AutoGenerateField = false)]
        public string CategoryName
        {
            get => categoryName;

            set => SetProperty(ref categoryName, value);
        }

        /// <summary>
        /// Gets or sets ConsumableTypeName
        /// </summary>
        [Display(AutoGenerateField = false)]
        public string TypeName
        {
            get => typeName;

            set => SetProperty(ref typeName, value);
        }

        /// <summary>
        /// Gets or sets ConsumableTypeDescription
        /// </summary>
        [Display(AutoGenerateField = false)]
        public string Description
        {
            get => description;

            set => SetProperty(ref description, value);
        }

        /// <summary>
        /// Gets or sets Production Date
        /// </summary>
        [Display(AutoGenerateField = false)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime? ProductionDate
        {
            get => productionDate;

            set => SetProperty(ref productionDate, value);
        }

        /// <summary>
        /// Gets or sets Expiry Date
        /// </summary>
        [Display(AutoGenerateField = false)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yy/MM/dd}")]
        public DateTime? ExpiryDate
        {
            get => expiryDate;

            set => SetProperty(ref expiryDate, value);
        }

        /// <summary>
        /// Gets or sets Lot Number
        /// </summary>
        [Display(AutoGenerateField = false)]
        public string Lot
        {
            get => lot;

            set => SetProperty(ref lot, value);
        }

        /// <summary>
        /// Gets or sets Serial Number
        /// </summary>
        [Display(AutoGenerateField = false)]
        public string Serial
        {
            get => serial;

            set => SetProperty(ref serial, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether it is already used
        /// </summary>
        [Display(AutoGenerateField = false)]
        public bool IsUsed { get; set; }

        /// <summary>
        /// Gets the Item Number if the GTIN is a valid LABORIE 14-digit number
        /// </summary>
        [Display(AutoGenerateField = false)]
        public int ItemNo => GetItemNo(gtin);

        /// <summary>
        /// Gets or sets the Display Image
        /// </summary>
        [Display(AutoGenerateField = false)]
        public BitmapImage DisplayImage { get; set; }

        /// <summary>
        /// Gets the company code
        /// </summary>
        [Display(AutoGenerateField = false)]
        public string CompanyCode => GetCompanyCode(gtin);

        /// <summary>
        /// Gets a value indicating whether LABORIE number is in GTIN
        /// </summary>
        /// <returns>Item Number</returns>
        [Display(AutoGenerateField = false)]
        public bool IsLaborieCode => CompanyCode.Equals(LaborieCompanyCode);

        /// <summary>
        /// Gets or sets Tag ID for DB
        /// </summary>
        [Display(AutoGenerateField = false)]
        public byte[] TagId
        {
            get => tagId;

            set => SetProperty(ref tagId, value);
        }

        /// <summary>
        /// Gets or sets Patient GUID
        /// </summary>
        [Display(AutoGenerateField = false)]
        public string PatientGuid
        {
            get => patientGuid;

            set => SetProperty(ref patientGuid, value);
        }

        /// <summary>
        /// Gets or sets the date of the initial consumable was used
        /// </summary>
        [Display(AutoGenerateField = false)]
        public DateTime? UsedDate
        {
            get => usedDate;

            set => SetProperty(ref usedDate, value);
        }

        /// <summary>
        /// Gets or sets the encrypted byte of SmartSense
        /// </summary>
        [Display(AutoGenerateField = false)]
        public byte[] EncryptedBytes
        {
            get => encryptedBytes;

            set => SetProperty(ref encryptedBytes, value);
        }

        [Display(AutoGenerateField = false)]
        public int Type { get; set; }

        [Display(AutoGenerateField = false)]
        public byte[] PatientIdCrc { get; set; }

        [Display(AutoGenerateField = false)]
        public byte Index { get; set; }

        [Display(AutoGenerateField = false)]
        public bool IsWritten { get; set; }

        [Display(AutoGenerateField = false)]
        public int Color { get; set; }

        #region DataGrid Columns

        /// <summary>
        /// Gets the CategoryName
        /// </summary>
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Label_CategoryName))]
        public string ConsumableGridCategoryName
        {
            get
            {
                var rgx = new Regex("[,]\\s|[,]");
                if (categoryName != null)
                {
                    return rgx.Replace(categoryName, "\n");
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        /// <summary>
        /// Gets ConsumableTypeName
        /// </summary>
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Label_ConsumableTypeName))]
        public string ConsumableGridPartNumber
        {
            get
            {
                var rgx = new Regex("[,]\\s|[,]");
                if (typeName != null)
                {
                    return rgx.Replace(typeName, "\n");
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        /// <summary>
        /// Gets ConsumableTypeDescription
        /// </summary>
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Label_ConsumableTypeDescription))]
        public string ConsumableGridDescription
        {
            get
            {
                var rgx = new Regex("[,]\\s|[,]");
                if (description != null)
                {
                    return rgx.Replace(description, "\n");
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        /// <summary>
        /// Gets Expiry Date to be displayed in DataGrid
        /// </summary>
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Label_Expiry_Date))]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yy/MM/dd}")]
        public DateTime? ConsumableGridExpiry => expiryDate;

        /// <summary>
        /// Gets Lot Number to be displayed in DataGrid
        /// </summary>
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Label_Lot))]
        public string ConsumableGridLotNumber => lot;

        /// <summary>
        /// Gets Serial Number to be displayed in DataGrid
        /// </summary>
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Label_Serial))]
        public string ConsumableGridSerialNumber => serial;

        #endregion

        /// <summary>
        /// Gets the company code of the GTIN
        /// </summary>
        /// <param name="gtin">GTIn code</param>
        /// <returns>company code</returns>
        public static string GetCompanyCode(string gtin)
        {
            return gtin.Substring(2, 6);
        }

        /// <summary>
        /// get the Item Number if the GTIN is a valid LABORIE 14-digit number
        /// </summary>
        /// <param name="gtin">GTIN code</param>
        /// <returns>Item Number</returns>
        public static int GetItemNo(string gtin)
        {
            int itemNo = 0;
            if (IsGtinValid(gtin))
            {
                int.TryParse(gtin.Substring(8, 5), out itemNo);
            }

            return itemNo;
        }

        /// <summary>
        /// Check if GTIN is a valid string and in supported company
        /// </summary>
        /// <param name="gtin">GTIN code</param>
        /// <returns>Item Number</returns>
        public static bool IsGtinValid(string gtin)
        {
            if (string.IsNullOrEmpty(gtin))
                return false;

            if (gtin.Length != Gtin14Length)
                return false;

            if (SupportedCompanyCodes.Find(x => x.Contains(GetCompanyCode(gtin))) == null)
                return false;

            return true;
        }

        /// <summary>
        /// get a clone of this BarcodeModel
        /// </summary>
        /// <returns>cloned object</returns>
        public object Clone()
        {
            return MemberwiseClone();
        }

        public bool Equals(BarcodeModel x, BarcodeModel y)
        {
            // Check whether the objects are the same object. 
            if (object.ReferenceEquals(x, y)) return true;

            // Check whether the barcode's Id are equal. 
            return x != null && y != null && x.BarCodeId.Equals(y.BarCodeId);
        }

        public int GetHashCode(BarcodeModel obj)
        {
            return obj.BarCodeId.GetHashCode();
        }

        public override string ToString()
        {
            var consumableString = new StringBuilder();
            consumableString.Append("Consumable:\r\n");

            // Tag ID
            if (TagId != null)
            {
                var tagId = BitConverter.ToUInt64(TagId, 0);
                consumableString.Append("Tag ID: " + tagId + "\r\n");
            }

            // GTIN
            consumableString.Append("GTIN: " + GTIN + "\r\n");

            // Lot Number
            consumableString.Append("Lot Number: " + Lot + "\r\n");

            // GTIN
            consumableString.Append("Serial Number: " + Serial + "\r\n");

            // Production Date
            if (ProductionDate != null)
                consumableString.Append("Production Date: " + ProductionDate + "\r\n");

            // Expiry Date
            if (ExpiryDate != null)
                consumableString.Append("Expiry Date: " + ExpiryDate + "\r\n");

            // Used Date
            consumableString.Append("Used Date: ");
            if (UsedDate != null)
                consumableString.Append(UsedDate);

            consumableString.Append("\r\n");

            // Patient ID
            consumableString.Append("Patient GUID: " + "\r\n");

            var patientIdCrc = string.Empty;
            if (PatientIdCrc != null)
            {
                // Patient ID CRC
                patientIdCrc = BitConverter.ToUInt16(PatientIdCrc, 0).ToString();
            }

            consumableString.Append("Patient GUID CRC: " + patientIdCrc + "\r\n\r\n");

            return consumableString.ToString();
        }
    }
}
