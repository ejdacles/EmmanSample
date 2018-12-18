// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Laborie">
//   Copyright (c) Laborie. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Laborie.Synergy.DataModel
{
    /// <summary>
    /// Extension to the Entity Framework auto generated Answer class
    /// </summary>
    public partial class Answer
    {
        /// <summary>
        /// Gets value for answer of Text type
        /// </summary>
        public string DisplayText
        {
            get
            {
                return this.Choice?.DisplayText;
            }
        }
    }
}
