// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Laborie">
//   Copyright (c) Laborie. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Laborie.Synergy.DataModel
{
    /// <summary>
    /// Allows workflows to grouped by investigation type
    /// These values are used in the database, existing values are not allowed to be changed
    /// </summary>
    public enum WorkflowInvestigationType
    {
        Unkown = 0,
        Urology = 1,
        Biofeedback = 2,
    }
}
