// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Laborie">
//   Copyright (c) Laborie. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Laborie.Synergy.BarcodeTraceability.Model
{
    /// <summary>
    /// Consumable Compatibility Matrix root Class
    /// </summary>
    public class ConsumableDataContract
    {
        /// <summary>
        /// Gets or sets the File Version
        /// </summary>
        public string FileVersion { get; set; }

        /// <summary>
        /// Gets or sets the Supported Synergy Version
        /// </summary>
        public string SupportedSynergyVersion { get; set; }

        /// <summary>
        /// Gets or sets the File Signature
        /// </summary>
        public string FileSignature { get; set; }

        /// <summary>
        /// Gets or sets Laborie Company Code
        /// </summary>
        public string LaborieCompanyCode { get; set; }

        /// <summary>
        /// Gets or sets Supported Company Codes
        /// </summary>
        public string[] SupportedCompanyCodes { get; set; }

        /// <summary>
        /// Gets or sets Channel-Consumable Categories
        /// </summary>
        public ChannelConsumableCategory[] ChannelConsumableCategories { get; set; }

        /// <summary>
        /// Gets or sets the Array of Consumable Types
        /// </summary>
        public ConsumableType[] ConsumableTypes { get; set; }
    }
}