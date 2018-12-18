// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Laborie">
//   Copyright (c) Laborie. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Laborie.Synergy.DataModel
{
    /// <summary>
    /// Enumeration for the phase icon
    /// These values are used in the database, existing values are not allowed to be changed
    /// </summary>
    public enum PhaseIconType
    {
        None = 0,
        Bridge = 1,
        Line = 2,
        Stimulation = 3,
        Preview = 4,
        LabelOnly = 5
    }
}
