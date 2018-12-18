// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Laborie">
//   Copyright (c) Laborie. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Laborie.Synergy.DataModel
{
    /// <summary>
    /// Workflow step types
    /// These values are used in the database, existing values are not allowed to be changed
    /// </summary>
    public enum WorkflowStepType
    {
        /// <summary>
        /// Default value to indicate the value is not set properly
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// Measurement procedure
        /// </summary>
        Procedure = 1,

        /// <summary>
        /// Review procedure
        /// </summary>
        Review = 2,

        /// <summary>
        /// Questionnaire type
        /// </summary>
        Questionnaire = 3,

        /// <summary>
        /// Report type
        /// </summary>
        Report = 4
    }
}
