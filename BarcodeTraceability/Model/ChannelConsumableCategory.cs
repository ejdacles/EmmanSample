// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Laborie">
//   Copyright (c) Laborie. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Laborie.Synergy.BarcodeTraceability.Model
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Laborie.Synergy.DataModel;

    /// <summary>
    /// Channel-Consumable Category class
    /// </summary>
    public class ChannelConsumableCategory
    {
        /// <summary>
        /// Gets or sets the Investigation Type
        /// </summary>
        public WorkflowInvestigationType InvestigationType { get; set; }

        /// <summary>
        /// Gets or sets the Channel Id
        /// </summary>
        public ChannelType ChannelType { get; set; }

        /// <summary>
        /// Gets or sets the Category Id
        /// </summary>
        public ConsumableCategory Category { get; set; }

        /// <summary>
        /// Gets or sets the Qualify Level
        /// </summary>
        public QualifyType QualifyLevel { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether it is Exclusive so the other exclusive category can be used for the channel at the same time
        /// </summary>
        public bool Exclusive { get; set; }
    }
}