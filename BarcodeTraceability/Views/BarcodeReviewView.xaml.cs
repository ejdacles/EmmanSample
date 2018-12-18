// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Laborie">
//   Copyright (c) Laborie. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Laborie.Synergy.BarcodeTraceability.Views
{
    using System.Globalization;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Markup;

    /// <summary>
    /// Interaction logic for BarcodeReviewView
    /// </summary>
    public partial class BarcodeReviewView : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BarcodeReviewView"/> class.
        /// </summary>
        public BarcodeReviewView()
        {
            // set the language from local culture to appropriately format it
            this.Language = XmlLanguage.GetLanguage(
                CultureInfo.CurrentCulture.IetfLanguageTag);

            InitializeComponent();
        }

        private void OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            Keyboard.Focus(sender as UserControl);
        }
    }
}
