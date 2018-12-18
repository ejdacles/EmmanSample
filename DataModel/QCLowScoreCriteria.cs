// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Laborie">
//   Copyright (c) Laborie. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Laborie.Synergy.DataModel
{
    /// <summary>
    /// <see cref="QCLowScoreCriteria"/> represents the criteria set for points that are applicable to a Low QC score
    /// </summary>
    public class QCLowScoreCriteria : QCScoreCriteria
    {
        public QCLowScoreCriteria()
        {
            ApplicablePoints = 0;
        }
    }
}
