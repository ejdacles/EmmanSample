// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Laborie">
//   Copyright (c) Laborie. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Laborie.Synergy.DataModel
{
    public enum ImageType
    {
        None = 0,

        /// <summary>
        /// Image of a single phase
        /// </summary>
        SinglePhase = 1,

        /// <summary>
        /// Overview image of the whole procedure
        /// </summary>
        ProcedureOverview = 2,

        /// <summary>
        /// Image Type
        /// </summary>
        Nomogram = 3,

        /// <summary>
        /// selected media for report
        /// </summary>
        SelectedMedia = 4,
    }
}
