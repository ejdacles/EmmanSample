// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Laborie">
//   Copyright (c) Laborie. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Laborie.Synergy.DataModel
{
    /// <summary>
    /// <see cref="QCScoreCriteria"/> represents the criteria set for each for points that are
    /// applicable to a QC score
    /// </summary>
    public abstract class QCScoreCriteria
    {
        /// <summary>
        /// Gets or sets the description set for the scoring criteria
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the points that are applicable for the score criteria
        /// </summary>
        public int ApplicablePoints { get; set; }
    }
}
