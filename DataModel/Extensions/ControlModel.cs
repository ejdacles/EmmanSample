// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Laborie">
//   Copyright (c) Laborie. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Laborie.Synergy.DataModel
{
    using System.Windows.Media;
    using Newtonsoft.Json;

    public partial class ControlModel
    {
        private string toolTip;

        /// <summary>
        /// Gets or sets the button background color
        /// </summary>
        public Color SelectedColor
        {
            get
            {
                var convertedColor = ColorConverter.ConvertFromString(BackGroundColor);
                return (Color?)convertedColor ?? Colors.Transparent;
            }

            set => BackGroundColor = value.ToString();
        }

        /// <summary>
        /// Gets or sets the button tooltip
        /// </summary>
        [JsonIgnore]
        public string ToolTip
        {
            get => string.IsNullOrEmpty(toolTip) ? Label : toolTip;

            set => toolTip = value;
        }
    }
}