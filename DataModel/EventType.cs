// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Laborie">
//   Copyright (c) Laborie. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Laborie.Synergy.DataModel
{
    using System.ComponentModel.DataAnnotations;
    using Translations;

    /// <summary>
    /// The event types.
    /// These values are used in the database, existing values are not allowed to be changed
    /// </summary>
    public enum EventType
    {
        ZeroChannel = 0,
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_EventType_Pause))]
        Pause = 1,
        Fatigue = 2,
        PhaseEvent = 3,
        CountDown = 4,
        Template = 5,
        Preview = 6,
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_EventType_EmgRelaxation))]
        EmgRelaxation = 7,
        ChannelMaximum = 8,
        ChannelMinimum = 9,
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_EventType_FlowMaximum))]
        FlowMaximum = 10,
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_EventType_StimulationMaximum))]
        StimulationMaximum = 11,
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_ResultType_LeakPointPressure))]
        LeakPointPressure = 12,
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_EventType_Valsalva))]
        Valsalva = 13,
        Container = 14,
        Root = 15,
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_EventType_PumpActive))]
        PumpActive = 16,
        PumpSpeed = 17,
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_EventType_StressTest))]
        StressTest = 18,
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_EventType_FirstSensation))]
        FirstSensation = 19,
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_EventType_FirstDesire))]
        FirstDesire = 20,
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_EventType_StrongDesire))]
        StrongDesire = 21,
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_EventType_MaximumCystometricCapacity))]
        MaximumCystometricCapacity = 22,
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_EventType_PermissionToVoid))]
        PermissionToVoid = 23,
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_EventType_PullerActive))]
        PullerActive = 24,
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_EventType_PullerReturn))]
        PullerReturn = 25,
        PullerDistance = 26,
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_EventType_Flow))]
        Flow = 27,
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_EventType_RestProfile))]
        RestProfile = 28,
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_EventType_StressProfile))]
        StressProfile = 29,
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_EventType_Artefact))]
        Artefact = 30,
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_EventType_Cough))]
        Cough = 31,
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_EventType_Profile))]
        Profile = 32,
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_EventType_Transmission))]
        Transmission = 33,
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_EventType_MUP))]
        MUP = 34,
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_EventType_MUCP))]
        MUCP = 35,
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_EventType_Compliance))]
        Compliance = 36,
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_EventType_SingleImage))]
        SingleImage = 37,
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_EventType_Video))]
        Video = 38,

        SelectableText = 39,
        FixedText = 40,
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_EventType_CustomEvent))]
        CustomEvent = 41,

        PvrInput = 42,
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_EventType_FlowArtifact))]
        FlowArtifact = 43,
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_EventType_MissingDataArtifact))]
        MissingDataArtifact = 44,
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_EventType_ClippedDataArtifact))]
        ClippedDataArtifact = 45,
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_EventType_DeviceConnectionLost))]
        DeviceConnectionLost = 46,
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_EventType_InfusionBagSpecificGravityChange))]
        InfusionBagSpecificGravityChange = 47,
        BladderSpecificGravityOnPhaseEnter = 48,
        PauseWithoutMarker = 49,
    }
}   
