// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Laborie">
//   Copyright (c) Laborie. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Laborie.Synergy.DataModel
{
    using Configuration.Interfaces;
    using System.Linq;
    using ProtocolModels;

    public class WorkflowModel : PropertyDictionary
    {
        public WorkflowModel(string name, ISettingsFallback settingsFallback, PropertyDictionary parentDictionary = null) : base(settingsFallback, name, parentDictionary)
        {
        }

        /// <summary>
        /// Gets or sets the type of investigation to which the workflow refers
        /// </summary>
        public WorkflowInvestigationType InvestigationType
        {
            get { return GetProperty<WorkflowInvestigationType>(PropertyDictionaryConstants.WorkflowInvestigationTypeKey); }
            set { SetProperty(PropertyDictionaryConstants.WorkflowInvestigationTypeKey, value); }
        }

        public IQueryable<WorkflowModel> WorkflowSteps { get; }
    }
}
