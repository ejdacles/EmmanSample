// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Laborie">
//   Copyright (c) Laborie. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Laborie.Synergy.DataModel
{
    /// <summary>
    /// The phase model types
    /// These values are used in the database, existing values are not allowed to be changed
    /// </summary>
    public enum PhaseModelTypes
    {
        Unknown = 0,
        RootPhase = 1,
        PreviewPhase = 2,
        ContainerPhase = 3,
        WorkPhase = 4,
        RestPhase = 5,
        StimulationPhase = 6,
        FlowPhase = 7,
        Fillingphase = 8,
        VoidingPhase = 9,
        ProfilePhase = 10,
    }
}
