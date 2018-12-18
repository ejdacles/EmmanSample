// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Laborie">
//   Copyright (c) Laborie. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Laborie.Synergy.DataModel
{
    using Translations;

    /// <summary>
    /// <see cref="QCIntermediateScoreCriteria"/> represents the criteria set for points that are applicable to a Intermediate QC score
    /// </summary>
    public class QCIntermediateScoreCriteria : QCScoreCriteria
    {
        public QCIntermediateScoreCriteria()
        {
            ApplicablePoints = 5;
        }
    }
}
