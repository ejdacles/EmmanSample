// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Laborie">
//   Copyright (c) Laborie. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Laborie.Synergy.DataModel
{
    /// <summary>
    /// Enumeration describing the different scrolling modes for the chart
    /// These values are used in the database, existing values are not allowed to be changed
    /// </summary>
    public enum ChartScrollingMode
    {
        NoScrolling = 0,
        Scrolling = 1,
        Stepping = 2,
        Sweeping = 3
    }
}
