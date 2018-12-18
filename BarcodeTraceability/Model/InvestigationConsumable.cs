// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Laborie">
//   Copyright (c) Laborie. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Laborie.Synergy.BarcodeTraceability.Model
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows.Media.Imaging;
    using Common;
    using DataModel;
    using DataStorage.Translations;
    using Translations;

    /// <summary>
    /// Consumable Class
    /// </summary>
    public class InvestigationConsumable : BindableBase
    {
        private string scannedSerial;

        /// <summary>
        /// Gets or sets the scanned Serial Number
        /// </summary>
        public string ScannedSerial
        {
            get
            {
                return scannedSerial;
            }

            set
            {
                SetProperty(ref scannedSerial, value);
                OnPropertyChanged(nameof(IsScanned));
                OnPropertyChanged(nameof(DisplayImagePath));
            }
        }

        /// <summary>
        /// Gets or sets the scanned Barcode Id
        /// </summary>
        public int ScannedBarcodeId { get; set; }

        /// <summary>
        /// Gets or sets the scanned Barcode Id
        /// </summary>
        public byte[] TagId { get; set; }

        /// <summary>
        /// Gets or sets the Required Consumable Category
        /// </summary>
        public ChannelConsumableCategory RequiredCategory { get; set; }

        /// <summary>
        /// Gets a value indicating whether Consumable is qualified
        /// </summary>
        public bool IsQualified => RequiredCategory?.QualifyLevel == QualifyType.Qualified;

        /// <summary>
        /// Gets a value indicating whether it has a scanned serial number
        /// </summary>
        public bool IsScanned => !string.IsNullOrEmpty(ScannedSerial);

        /// <summary>
        /// Gets the channel name for the required consumable item
        /// </summary>
        public string ChannelName => GetChannelTypeName(RequiredCategory.ChannelType);

        /// <summary>
        /// Gets the Consumable Category name to display
        /// </summary>
        public string CategoryName
        {
            get
            {
                if (RequiredCategory == null)
                    return string.Empty;

                string name = GetCategoryName(RequiredCategory.Category);

                return RequiredCategory.Exclusive ? $"{name} (OR)" : name;
            }
        }

        /// <summary>
        /// Gets the image for Qualified/Secondary/Scanned Consumable
        /// </summary>
        public object DisplayImagePath
        {
            get
            {
                if (IsScanned)
                {
                    return new BitmapImage(new Uri(@"/Laborie.Synergy.BarcodeTraceability;component/Images/ic_checkbox-selected.png", UriKind.Relative));
                }
                else
                {
                    if (IsQualified)
                    {
                        return new BitmapImage(new Uri(@"/Laborie.Synergy.BarcodeTraceability;component/Images/ic_checkbox-sm-hover.png", UriKind.Relative));
                    }
                    else
                    {
                        return new BitmapImage(new Uri(@"/Laborie.Synergy.BarcodeTraceability;component/Images/ic_checkbox.png", UriKind.Relative));
                    }
                }
            }
        }

        /// <summary>
        /// get Consumable Category name to display
        /// </summary>
        /// <param name="category">Consumable Category</param>
        /// <returns>category name</returns>
        public static string GetCategoryName(ConsumableCategory category)
        {
            switch (category)
            {
                case ConsumableCategory.PatchElectrodes:
                    return Translations.Language.Label_PatchElectrodes;
                case ConsumableCategory.StimProbe:
                    return Translations.Language.Label_StimProbe;
                case ConsumableCategory.ManometryProbe:
                    return Translations.Language.Label_ManometryProbe;
                case ConsumableCategory.ManometryTubing:
                    return Translations.Language.Label_ManometryTubing;
                case ConsumableCategory.EmgProbe:
                    return Translations.Language.Label_EMGProbe;
                case ConsumableCategory.PvesCatheter:
                    return Translations.Language.Label_PvesCatheter;
                case ConsumableCategory.PabdCatheter:
                    return Translations.Language.Label_PabdCatheter;
                case ConsumableCategory.PuraCatheter:
                    return Translations.Language.Label_PuraCatheter;
                case ConsumableCategory.VinfCatheter:
                    return Translations.Language.Label_VinfCatheter;
                case ConsumableCategory.VinfTubing:
                    return Translations.Language.Label_VinfTubing;
            }

            return string.Empty;
        }

        /// <summary>
        /// get all the Supported Category Names of consumable Type
        /// </summary>
        /// <param name="consumableType">consumable Type</param>
        /// <returns>Category Names</returns>
        public static string GetSupportedCategoryNames(ConsumableType consumableType)
        {
            IEnumerable<ConsumableCategory> categories = GetSupportedCategories(consumableType);

            StringBuilder sb = new StringBuilder();
            foreach (var category in categories)
            {
                if (sb.Length > 0)
                {
                    sb.Append(", ");
                }

                sb.Append(GetCategoryName(category));
            }

            return sb.ToString();
        }

        public static string GetSupportedCategoryNames(ConsumableType consumableType, int color)
        {
            IEnumerable<ConsumableCategory> categories = GetSupportedCategories(consumableType, color);

            StringBuilder sb = new StringBuilder();
            foreach (var category in categories)
            {
                if (sb.Length > 0)
                {
                    sb.Append(", ");
                }

                sb.Append(GetCategoryName(category));
            }

            return sb.ToString();
        }

        /// <summary>
        /// get all the Supported Categories of consumable Type
        /// </summary>
        /// <param name="consumableType">consumable Type</param>
        /// <returns>Supported Categories</returns>
        public static IEnumerable<ConsumableCategory> GetSupportedCategories(ConsumableType consumableType, int color = 0)
        {
            var categories = new List<ConsumableCategory>();
            if (color == 0 || color == 1)
                AddConsumableCategory(categories, consumableType.PabdCatheter, ConsumableCategory.PabdCatheter);
            if (color == 0 || color == 2)
                AddConsumableCategory(categories, consumableType.PuraCatheter, ConsumableCategory.PuraCatheter);
            if (color == 0 || color == 3)
                AddConsumableCategory(categories, consumableType.PvesCatheter, ConsumableCategory.PvesCatheter);

            AddConsumableCategory(categories, consumableType.VinfCatheter, ConsumableCategory.VinfCatheter);
            AddConsumableCategory(categories, consumableType.VinfTubing, ConsumableCategory.VinfTubing);
            AddConsumableCategory(categories, consumableType.EmgProbe, ConsumableCategory.EmgProbe);
            AddConsumableCategory(categories, consumableType.Patches, ConsumableCategory.PatchElectrodes);
            AddConsumableCategory(categories, consumableType.ManometryProbe, ConsumableCategory.ManometryProbe);
            AddConsumableCategory(categories, consumableType.ManometryTubing, ConsumableCategory.ManometryTubing);
            AddConsumableCategory(categories, consumableType.StimProbe, ConsumableCategory.StimProbe);
            return categories;
        }

        private static void AddConsumableCategory(List<ConsumableCategory> categories, bool isFeatureExisted, ConsumableCategory category)
        {
            if (isFeatureExisted)
            {
                categories.Add(category);
            }
        }

        private static string GetChannelTypeName(ChannelType channelType)
        {
            switch (channelType)
            {
                case ChannelType.NotSet:
                    return DataStorage.Translations.Language.Channel_NotSet;
                case ChannelType.Pves:
                    return DataStorage.Translations.Language.Channel_Pves;
                case ChannelType.Pura:
                    return DataStorage.Translations.Language.Channel_Pura;
                case ChannelType.Pabd:
                    return DataStorage.Translations.Language.Channel_Pabd;
                case ChannelType.Pclos:
                    return DataStorage.Translations.Language.Channel_Pclos;
                case ChannelType.Pdet:
                    return DataStorage.Translations.Language.Channel_Pdet;
                case ChannelType.Flow:
                    return DataStorage.Translations.Language.Channel_FlowRate;
                case ChannelType.Volume:
                    return DataStorage.Translations.Language.Channel_FlowVolume;
                case ChannelType.InfusedVolume:
                    return DataStorage.Translations.Language.Channel_Vin;
                case ChannelType.Stimulation:
                    return DataStorage.Translations.Language.Channel_Stimulation;
                case ChannelType.BladderVolume:
                    return DataStorage.Translations.Language.Channel_BladderVolume;
                case ChannelType.Emg:
                    return DataStorage.Translations.Language.Channel_EMG;
                case ChannelType.EmgPelvic:
                    return DataStorage.Translations.Language.Channel_EmgPelvic;
                case ChannelType.EmgAbd:
                    return DataStorage.Translations.Language.Channel_EmgAbd;
                case ChannelType.Pressure:
                    return DataStorage.Translations.Language.Channel_Pressure;
            }

            return string.Empty;
        }
    }
}
