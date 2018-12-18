// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Laborie">
//   Copyright (c) Laborie. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Laborie.Synergy.DataModel.Utils
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Helper method for setting <see cref="PhaseModel"/>'s child phases
    /// </summary>
    public static class PhaseModelChildPhaseHelper
    {
        /// <summary>
        /// Adds the specified child phase to the collection AND sets the parent phase property of the specified child phase
        /// </summary>
        /// <param name="parentPhaseModel">The phase parentPhaseModel which is to receive the child phase</param>
        /// <param name="childPhase">The child phase to add to the parent's collection</param>
        public static void AddChildPhase(this PhaseModel parentPhaseModel, PhaseModel childPhase)
        {
            if (childPhase == null)
                return;

            childPhase.ParentPhase = parentPhaseModel;
            parentPhaseModel.ChildPhases.Add(childPhase);
        }

        /// <summary>
        /// Adds the specified child phases to the collection AND sets the parent phase property of the specified child phases
        /// </summary>
        /// <param name="parentPhaseModel">The phase which is to receive the child phases</param>
        /// <param name="childPhaseCollection">The child phases to add to the parent's collection</param>
        public static void AddMultipleChildPhases(this PhaseModel parentPhaseModel, IList<PhaseModel> childPhaseCollection)
        {
            if (childPhaseCollection == null)
                return;

            foreach (var childPhase in childPhaseCollection)
            {
                parentPhaseModel.AddChildPhase(childPhase);
            }
        }
    }
}
