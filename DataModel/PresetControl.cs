// -------------------------------------------------------------------------------------------------------------------
// <copyright company="Laborie">
//   Copyright (c) Laborie. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Laborie.Synergy.DataModel
{
    /// <summary>
    /// Characterizes preset buttons for control panel.
    /// These values are used in the database, existing values are not allowed to be changed
    /// </summary>
    public enum PresetControl
    {
        EmptyButton = 0,
        PumpToggleButton = 1,
        PumpOnButton = 2,
        PumpOffButton = 3,
        PumpUpButton = 4,
        PumpDownButton = 5,
        PullerToggleButton = 6,
        PullerOnButton = 7,
        PullerOffButton = 8,
        PullerReturnButton = 9,

        AutoScaleEmgChannelsButton = 10,
        ResetEmgScalesToDefaultButton = 11,

        AutoScalePressureChannelsButton = 12,
        ResetPressureScalesToDefaultButton = 13,

        SetStimulationLevelButton = 14,
        StopStimulationButton = 15,

        ZeroAllPressureChannelsButton = 16,
        ZeroUroflowVolumeButton = 17,
        ZeroPdetButton = 18,
        ZeroPclosButton = 19,

        ZoomOutButton = 20,
        ZoomPreviousButton = 21,

        QuestionnaireButton = 22,
        ResultsButton = 23,
        ReportButton = 24,
        TakeSnapshotButton = 25,
        CineloopToggleButton = 26,

        TextSequentialButton = 27,
        
        SmartPumpUpButton = 28,
        SmartPumpDownButton = 29,
        SlowPumpSpeedButton = 30,
        MediumPumpSpeedButton = 31,
        FastPumpSpeedButton = 32,

        FixedTextButton = 33,
        ChangeWaterbagButton = 34,

        PrimePumpTubeToggleButton = 35,

        #region Place Markers (1001 - 2000)
        EmgRelaxationMarkerButton = 1001,
        FatiguePointMarkerButton = 1002,
        LeakpointPressureButton = 1003,

        // TODO : remove MictionButtonButton , this is here to fix a failing smoke test 87723
        MictionButton = 1004,
        PermissionToVoidButton = 1004,

        RestProfileToggleButton = 1005,
        StressProfileToggleButton = 1006,

        ValsalvaToggleButton = 1007,

        // TODO : remove CLPPToggleButton , this is here to fix a failing smoke test 87723
        ClppToggleButton = 1008,
        StressTestToggleButton = 1008,

        SensationsSequentialButton = 1009,
        FirstSensationButton = 1010,
        FirstDesireButton = 1011,
        StrongDesireButton = 1012,
        MaximumCystometricCapacityButton = 1013,
        #endregion
    }
}
