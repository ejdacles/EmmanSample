// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Laborie">
//   Copyright (c) Laborie. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Laborie.Synergy.DataModel
{
    /// <summary>
    /// Identification of the actions that a control in the control panel can have.
    /// These values are used in the database, existing values are not allowed to be changed
    /// </summary>
    public enum ControlAction
    {
        DoNothing = 0,

        #region Actions (1 - 1000)
        AutoScaleEmgChannels = 1,
        ResetEmgScalesToDefault = 2,

        AutoScalePressureChannels = 3,
        ResetPressureScalesToDefault = 4,

        SetStimulationLevel = 5,
        StopStimulation = 6,

        ZeroAllPressureChannels = 7,
        ZeroUroflowVolume = 8,
        ZeroPdet = 9,
        ZeroPclos = 10,

        PumpOn = 11,
        PumpOff = 12,
        PumpUp = 13,
        PumpDown = 14,

        PullerOn = 15,
        PullerOff = 16,
        PullerReturn = 17,

        ZoomOut = 18,
        ZoomPrevious = 19,

        Questionnaire = 20,
        Results = 21,
        Report = 22,

        CreateFreeText = 23,

        SmartPumpUp = 24,
        SmartPumpDown = 25,
        SlowPumpSpeed = 26,
        MediumPumpSpeed = 27,
        FastPumpSpeed = 28,

        CreateFixedText = 29,
        ChangeWaterbag = 30,

        PrimePumpTubeOn = 31,
        PrimePumpTubeOff = 32,

        #endregion

        #region Place Markers (1001 - 2000)
        PlaceEmgRelaxationMarker = 1001,
        PlaceFatiguePointMarker = 1002,
        PlaceLeakpointPressureMarker = 1003,
        
        // TODO : remove PlaceMictionMarker, this is here to fix a failing smoke test 87723
        PlacePermissionToVoidMarker = 1004,
        PlaceMictionMarker = 1004,

        PlaceRestProfileMarker = 1005,
        PlaceRestProfileEndMarker = 1006,

        PlaceStressProfileMarker = 1007,
        PlaceStressProfileEndMarker = 1008,

        PlaceValsalvaMarker = 1009,
        PlaceValsalvaEndMarker = 1010,

        // TODO : remove PlaceClppMarker, this is here to fix a failing smoke test 87723
        PlaceStressTestMarker = 1011,
        PlaceClppMarker = 1011,

        // TODO : remove PlaceClppEndMarker, this is here to fix a failing smoke test 87723
        PlaceStressTestEndMarker = 1012,
        PlaceClppEndMarker = 1012,

        PlaceFirstSensationMarker = 1013,
        PlaceFirstDesireMarker = 1014,
        PlaceStrongDesireMarker = 1015,
        PlaceMaximumCystometricCapacityMarker = 1016,

        PlaceFreeTextMarker = 1017,
        PlaceSupineFreeTextMarker = 1018,
        PlaceSittingFreeTextMarker = 1019,
        PlaceStandingFreeTextMarker = 1020,

        PlaceFixedTextMarker = 1021,

        #endregion

        #region Video Actions (2001 - 3000)
        TakeSnapshot = 2001,
        StartCineloopDiskVideo = 2002,
        StopCineloopDiskVideo = 2003
        #endregion
    }
}
