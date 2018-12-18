// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Laborie">
//   Copyright (c) Laborie. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Laborie.Synergy.DataModel
{
    /// <summary>
    /// Extension to the Entity Framework auto generated Answer class
    /// </summary>
    public partial class WorkflowStepConfiguration
    {
        /// <summary>
        /// Gets the investigation type determined by the workflow configuration.
        /// </summary>
        public WorkflowInvestigationType InvestigationType => WorkflowConfiguration?.InvestigationType ?? WorkflowInvestigationType.Unkown;
    }
}
