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
    using Model;

    /// <summary>
    /// Class to convert String to bool if Null or Empty
    /// </summary>
    public class StringEmptyConverter : IValueConverter
    {
        /// <summary>
        /// Converts Consumable Category into Icon path
        /// </summary>
        /// <param name="value">Consumable Category Value</param>
        /// <param name="targetType">Target Type</param>
        /// <param name="parameter">Object Parameter</param>
        /// <param name="culture">Culture Info</param>
        /// <returns>Icon image</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (string.IsNullOrEmpty(value?.ToString()))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Do not use
        /// </summary>
        /// <param name="value">The value that is produced by the binding target</param>
        /// <param name="targetType">target type</param>
        /// <param name="parameter">parameter object</param>
        /// <param name="culture">culture info</param>
        /// <returns>A converted value.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
