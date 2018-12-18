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
    using System.Windows.Media.Imaging;
    using Model;

    /// <summary>
    /// Class to convert Consumable Category into Icon path
    /// </summary>
    public class ConsumableIconConverter : IValueConverter
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
            BitmapImage icon = null;
            if (value != null)
            {
                switch ((ConsumableCategory)value)
                {
                    case ConsumableCategory.PatchElectrodes:
                        icon = new BitmapImage(new Uri(@"/Laborie.Synergy.BarcodeTraceability;component/Resources/PatchElectrodes.png", UriKind.Relative));
                        break;
                    case ConsumableCategory.StimProbe:
                        icon = new BitmapImage(new Uri(@"/Laborie.Synergy.BarcodeTraceability;component/Resources/StimProbe.png", UriKind.Relative));
                        break;
                    case ConsumableCategory.ManometryProbe:
                        icon = new BitmapImage(new Uri(@"/Laborie.Synergy.BarcodeTraceability;component/Resources/ManometryProbe.png", UriKind.Relative));
                        break;
                    case ConsumableCategory.ManometryTubing:
                        icon = new BitmapImage(new Uri(@"/Laborie.Synergy.BarcodeTraceability;component/Resources/ManometryTubing.png", UriKind.Relative));
                        break;
                    case ConsumableCategory.EmgProbe:
                        icon = new BitmapImage(new Uri(@"/Laborie.Synergy.BarcodeTraceability;component/Resources/EMGProbe.png", UriKind.Relative));
                        break;
                    case ConsumableCategory.PvesCatheter:
                        icon = new BitmapImage(new Uri(@"/Laborie.Synergy.BarcodeTraceability;component/Resources/PvesCatheter.png", UriKind.Relative));
                        break;
                    case ConsumableCategory.PabdCatheter:
                        icon = new BitmapImage(new Uri(@"/Laborie.Synergy.BarcodeTraceability;component/Resources/PabdCatheter.png", UriKind.Relative));
                        break;
                    case ConsumableCategory.PuraCatheter:
                        icon = new BitmapImage(new Uri(@"/Laborie.Synergy.BarcodeTraceability;component/Resources/PuraCatheter.png", UriKind.Relative));
                        break;
                    case ConsumableCategory.VinfCatheter:
                        icon = new BitmapImage(new Uri(@"/Laborie.Synergy.BarcodeTraceability;component/Resources/VinfCatheter.png", UriKind.Relative));
                        break;
                    case ConsumableCategory.VinfTubing:
                        icon = new BitmapImage(new Uri(@"/Laborie.Synergy.BarcodeTraceability;component/Resources/VinfTubing.png", UriKind.Relative));
                        break;
                }
            }

            return icon;
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
