// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Laborie">
//   Copyright (c) Laborie. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Laborie.Synergy.DataModel
{
    /// <summary>
    /// <see cref="PrimaryReasonGroup"/> represents the various groups using which the various patient 
    /// symptoms are categorised
    /// </summary>
    public enum PrimaryReasonGroup
    {
        NotSet = 0,
        Incontinence = 1,
        StorageConditions = 2,
        Sensory = 3,
        StorageFunctional = 4,
        VoidingTypes = 5,
        PoorVoiding = 6,
        PatientReporting = 7,
        VoidingConditions = 8,
        VoidingFunctional = 9,
        SpecialCases = 10
    }
}