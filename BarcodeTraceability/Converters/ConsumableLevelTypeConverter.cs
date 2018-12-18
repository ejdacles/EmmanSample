// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Laborie">
//   Copyright (c) Laborie. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Laborie.Synergy.BarcodeTraceability.Converters
{
    using System;
    using System.Globalization;
    using System.Windows.Data;
    using Translations;

    /// <summary>
    /// Class to Convert QualifyLevelType into string
    /// </summary>
    public class ConsumableLevelTypeConverter : IValueConverter
    {
        /// <summary>
        /// Convert QualifyLevelType into string
        /// </summary>
        /// <param name="value">DateTime Value</param>
        /// <param name="targetType">Target Type</param>
        /// <param name="parameter">Object Parameter</param>
        /// <param name="culture">Culture Info</param>
        /// <returns>string</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                var level = (int)value;
                switch (level)
                {
                    case 1: return Language.Label_Automatic;
                    case 2: return Language.Label_Manual;                    
                }
            }

            return Language.Label_OtherConsumable;
        }

        /// <summary>
        /// Not implemented.
        /// </summary>
        /// <param name="value">String Value</param>
        /// <param name="targetType">Target Type</param>
        /// <param name="parameter">Object Parameter</param>
        /// <param name="culture">Culture Info</param>
        /// <returns>Object</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
