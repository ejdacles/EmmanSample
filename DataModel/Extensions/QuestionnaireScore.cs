// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Laborie">
//   Copyright (c) Laborie. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Laborie.Synergy.DataModel
{
    /// <summary>
    /// Extension to the Entity Framework auto generated QuestionnaireScore class
    /// </summary>
    public partial class QuestionnaireScore
    {
        /// <summary>
        /// Gets Name for Score Formula
        /// </summary>
        public string ScoreName
        {
            get
            {
                return this.Formula.Name;
            }
        }
    }
}
