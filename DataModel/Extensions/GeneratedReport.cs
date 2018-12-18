// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Laborie">
//   Copyright (c) Laborie. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Laborie.Synergy.DataModel
{
    /// <summary>
    /// Extension to the Entity Framework auto generated GenerateReport class
    /// </summary>
    public partial class GeneratedReport
    {
        /// <summary>
        /// Gets Physical File Name for the REPX file.
        /// </summary>
        public string REPXFileName
        {
            get
            {
                return string.IsNullOrEmpty(Report?.Name) ? string.Empty : string.Format("{0}.repx", this.Report?.Name);
            }
        }
    }
}
