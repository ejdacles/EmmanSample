// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Laborie">
//   Copyright (c) Laborie. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Laborie.Synergy.BarcodeTraceability.Behaviors
{
    using System;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;

    /// <summary>
    /// Class that only accepts Integer values in TextBox.
    /// </summary>
    public class NumericTextBoxBehavior
    {
        /// <summary>
        /// Gets or Set IsEnabledProperty
        /// </summary>
        public static readonly DependencyProperty IsEnabledProperty = DependencyProperty.RegisterAttached("IsEnabled", typeof(bool), typeof(NumericTextBoxBehavior), new UIPropertyMetadata(false, OnValueChanged));

        /// <summary>
        /// Get if Control is Enabled
        /// </summary>
        /// <param name="control">Control Type</param>
        /// <returns>True or False</returns>
        public static bool GetIsEnabled(Control control)
        {
            return (bool)control.GetValue(IsEnabledProperty);
        }

        /// <summary>
        /// Set Control to enabled or disabled.
        /// </summary>
        /// <param name="control">Control Type</param>
        /// <param name="value">Enabled or Disabled</param>
        public static void SetIsEnabled(Control control, bool value)
        {
            control.SetValue(IsEnabledProperty, value);
        }

        /// <summary>
        /// OnValuedChanged Property
        /// </summary>
        /// <param name="dependencyObject">Dependency Object</param>
        /// <param name="e">Dependency Args</param>
        private static void OnValueChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            var controlElement = dependencyObject as Control;
            if (controlElement == null)
                return;
            if (e.NewValue is bool && (bool)e.NewValue)
            {
                controlElement.PreviewTextInput += OnTextInput;
                controlElement.PreviewKeyDown += OnPreviewKeyDown;
                DataObject.AddPastingHandler(controlElement, OnPaste);
            }
            else
            {
                controlElement.PreviewTextInput -= OnTextInput;
                controlElement.PreviewKeyDown -= OnPreviewKeyDown;
                DataObject.RemovePastingHandler(controlElement, OnPaste);
            }
        }

        private static void OnTextInput(object sender, TextCompositionEventArgs e)
        {
            if (e.Text.Any(c => !char.IsDigit(c)))
            {
                e.Handled = true;
            }
        }

        private static void OnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space) e.Handled = true;
        }

        private static void OnPaste(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(DataFormats.Text))
            {
                var text = Convert.ToString(e.DataObject.GetData(DataFormats.Text)).Trim();
                if (text.Any(c => !char.IsDigit(c)))
                {
                    e.CancelCommand();
                }
            }
            else
            {
                e.CancelCommand();
            }
        }
    }
}
