// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Laborie">
//   Copyright (c) Laborie. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Laborie.Synergy.BarcodeTraceability.Views
{
    using System;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Markup;
    using System.Windows.Media;
    using Common.UI.ViewModel;

    /// <summary>
    /// Interaction logic for BarcodeView control.
    /// </summary>
    public partial class BarcodeView : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BarcodeView"/> class.
        /// </summary>
        public BarcodeView()
        {
            this.Language = XmlLanguage.GetLanguage(
                CultureInfo.CurrentCulture.IetfLanguageTag);

            InitializeComponent();
            Unloaded += (sender, args) => BarcodeView_Unloaded();
            Dispatcher.ShutdownStarted += (sender, args) => Dispatcher_ShutdownStarted();
        }

        public static T FindVisualChildByName<T>(DependencyObject parent, string name) where T : DependencyObject
        {
            for (var i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                var controlName = child.GetValue(Control.NameProperty) as string;
                if (controlName == name)
                {
                    return child as T;
                }
                else
                {
                    var result = FindVisualChildByName<T>(child, name);
                    if (result != null)
                        return result;
                }
            }

            return null;
        }

        private void Dispatcher_ShutdownStarted()
        {
            BarcodeView_Unloaded();
        }

        private void BarcodeView_Unloaded()
        {
            var disposable = DataContext as IDisposable;
            if (!ReferenceEquals(null, disposable))
            {
                disposable.Dispose();
            }
        }

        private void Bypass_OnClick(object sender, RoutedEventArgs e)
        {
            var buttonPanelControl = FindVisualChildByName<UserControl>(Application.Current.MainWindow, "ButtonPanelControl");
            var context = (ButtonPanelViewModel)buttonPanelControl?.DataContext;
            context?.CollapseButtonPanelCommand.Execute(null);
        }
    }
}
