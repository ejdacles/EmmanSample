// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Laborie">
//   Copyright (c) Laborie. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Laborie.Synergy.DataModel
{
    using System.Collections.Generic;

    /// <summary>
    /// The Phases interface.
    /// </summary>
    public interface IPhases
    {
        /// <summary>
        /// Gets the parent.
        /// </summary>
        PhaseModel Parent { get; }

        /// <summary>
        /// Gets the phases.
        /// </summary>
        ICollection<PhaseModel> Phases { get; }
    }
}