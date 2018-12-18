// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Laborie">
//   Copyright (c) Laborie. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Laborie.Synergy.DataModel
{
    public class PhaseSwitchInformation
    {
        public PhaseModelTypes? CurrentPhaseType { get; set; }

        public PhaseModelTypes? NextPhaseType { get; set; }

        public bool AutoStartNextPhase { get; set; }
    }
}
