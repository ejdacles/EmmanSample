// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Laborie">
//   Copyright (c) Laborie. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Laborie.Synergy.DataModel
{
    /// <summary>
    /// The quality step types
    /// These values are used in the database, existing values are not allowed to be changed
    /// </summary>
    public enum QualityStepModelTypes
    {
        Unknown = 0,
        Category = 1,
        Flow = 2,
        Step = 3
    }
}