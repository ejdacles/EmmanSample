// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Laborie">
//   Copyright (c) Laborie. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Laborie.Synergy.DataModel
{
    using System.Windows;

    /// <summary>
    /// Extension to the Entity Framework auto generated ChannelMapping class
    /// </summary>
    public partial class ChannelMapping
    {
        /// <summary>
        /// Gets or sets the display name.
        /// </summary>
        /// <value>
        /// The display name.
        /// </value>
        public string DisplayName { get; set; }

        public Visibility PressureIconVisibility { get; set; } = Visibility.Hidden;

        public string PressureIconDisplay { get; set; } = string.Empty;

        public string PressureIconColor { get; set; } = "Black";
    }
}
