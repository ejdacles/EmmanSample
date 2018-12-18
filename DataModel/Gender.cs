// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Laborie">
//   Copyright (c) Laborie. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Laborie.Synergy.DataModel
{
    /// <summary>
    /// Enumeration for the Gender
    /// These values are used in the database, existing values are not allowed to be changed
    /// </summary>
    public enum Gender
    {
        /// <summary>None is the default value when a new patient is created</summary>
        None = 0,
        Male = 1,
        Female = 2
    }
}
