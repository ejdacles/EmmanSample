// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Laborie">
//   Copyright (c) Laborie. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Laborie.Synergy.DataModel
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.SqlServer;
    using System.Runtime.Remoting.Messaging;

    /// <summary>
    /// The custom database configuration.
    /// </summary>
    public class SynergyDbConfiguration : DbConfiguration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SynergyDbConfiguration"/> class.
        /// </summary>
        public SynergyDbConfiguration()
        {
            this.SetExecutionStrategy("System.Data.SqlClient", () => (IDbExecutionStrategy)new DefaultExecutionStrategy());
        }

        /// <summary>
        /// Gets or sets a value indicating whether the default execution strategy has a Suspended SqlAzureExecutionStrategy execution strategy.
        /// </summary>
        public static bool SuspendExecutionStrategy
        {
            get
            {
                return (bool?)CallContext.LogicalGetData("SuspendExecutionStrategy") ?? false;
            }

            set
            {
                CallContext.LogicalSetData("SuspendExecutionStrategy", value);
            }
        }
    }
}