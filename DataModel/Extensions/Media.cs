// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Laborie">
//   Copyright (c) Laborie. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Laborie.Synergy.DataModel
{
    using System.Windows.Media.Imaging;

    /// <summary>
    /// Expansion of the event.
    /// </summary>
    public partial class Media
    {
        public string ResourceFileName { get; set; }

        public BitmapImage ResourceImage { get; set; }
    }
}
