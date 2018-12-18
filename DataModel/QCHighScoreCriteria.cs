// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Laborie">
//   Copyright (c) Laborie. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Laborie.Synergy.DataModel
{
    /// <summary>
    /// <see cref="QCHighScoreCriteria"/> represents the criteria set for points that are applicable to a High QC score
    /// </summary>
    public class QCHighScoreCriteria : QCScoreCriteria
    {
        public QCHighScoreCriteria()
        {
            ApplicablePoints = 10;
        }
    }
}
