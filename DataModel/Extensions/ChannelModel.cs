// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Laborie">
//   Copyright (c) Laborie. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Laborie.Synergy.DataModel
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Media;

    /// <summary>
    /// Extension to the Entity Framework auto generated GenerateReport class
    /// </summary>
    public partial class ChannelModel
    {
        private const char DependentChannelIndexesStringSeparator = ',';

        /// <summary>
        /// Gets or sets collection of dependent channel indexes.
        /// DependentChannelIndexesString
        /// </summary>
        /// <value>
        /// The collection of dependent channel indexes.
        /// </value>
        public IList<int> DependentChannelIndexes
        {
            get => string.IsNullOrEmpty(DependentChannelIndexesString) ?
                            new List<int>() :
                            DependentChannelIndexesString.Split(DependentChannelIndexesStringSeparator).Select(int.Parse).ToList();

            set
            {
                DependentChannelIndexesString = string.Join(DependentChannelIndexesStringSeparator.ToString(), value);
            }
        }

        /// <summary>
        /// Gets or sets the line color used for the channel in the graph
        /// </summary>
        public Color LineColor
        {
            get
            {
                var convertedColor = ColorConverter.ConvertFromString(LineColorInternal);
                return (Color?)convertedColor ?? Colors.Transparent;
            }

            set
            {
                LineColorInternal = value.ToString();
            }
        }
    }
}