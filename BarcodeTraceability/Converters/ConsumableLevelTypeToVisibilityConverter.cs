// <copyright file="ConsumableLevelTypeToBoolConverter.cs" company="Laborie">
// Copyright (c) Laborie. All rights reserved.
// </copyright>

namespace Laborie.Synergy.BarcodeTraceability.Converters
{
    using System;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;
    using Translations;

    /// <summary>
    /// Class to Convert QualifyLevelType into string
    /// </summary>
    public class ConsumableLevelTypeToVisibilityConverter : IValueConverter
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
            return (int?)value == 1 ? Visibility.Hidden : Visibility.Visible;
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
