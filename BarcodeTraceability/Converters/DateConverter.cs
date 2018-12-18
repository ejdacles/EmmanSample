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

    /// <summary>
    /// Class to Convert String into Date Format
    /// </summary>
    public class DateConverter : IValueConverter
    {
        /// <summary>
        /// Converts Date format to String
        /// </summary>
        /// <param name="value">DateTime Value</param>
        /// <param name="targetType">Target Type</param>
        /// <param name="parameter">Object Parameter</param>
        /// <param name="culture">Culture Info</param>
        /// <returns>Date String</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                DateTime date = (DateTime)value;
                if (date.Year > 1900)
                    return ((DateTime)value).ToString(CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern);
            }

            return string.Empty;
        }

        /// <summary>
        /// Converts String to Date format.
        /// </summary>
        /// <param name="value">String Value</param>
        /// <param name="targetType">Target Type</param>
        /// <param name="parameter">Object Parameter</param>
        /// <param name="culture">Culture Info</param>
        /// <returns>Date Object</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime date = default(DateTime);
            if (!string.IsNullOrEmpty((string)value))
            {
                if (DateTime.TryParseExact(value.ToString(), CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern, CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                    return date;
            }

            return date;
        }
    }
}
