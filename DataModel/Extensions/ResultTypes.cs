// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Laborie">
//   Copyright (c) Laborie. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Laborie.Synergy.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Translations;

    /// <summary>
    /// Identification of a procedure result
    /// These values are used in the database, existing values are not allowed to be changed
    /// </summary>
    /// <remarks>
    /// DisplayAttribute is used by <see cref="ResultsHelper"/> to determine the "Friendly Name" of the result.
    /// Results related to only one event should have a DisplayAttribute.
    /// If the result is associated to many events, it should be added to the <see cref="ResultsHelper"/> switch statement.
    /// </remarks>
    public enum ResultTypes
    {
        Unknown = 0,

        #region Stimulation Results (1 - 1000)

        /// <summary>
        /// Mean stimulation level
        /// </summary>
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_ResultType_MeanStimulationLevel))]
        MeanStimulationLevel = 1,

        /// <summary>
        /// Maximum stimulation level
        /// </summary>
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_ResultType_MaxStimulationLevel))]
        MaxStimulationLevel = 2,

        /// <summary>
        /// Number of repeats performed
        /// </summary>
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_ResultType_NumberOfRepeatsPerformed))]
        NumberOfRepeatsPerformed = 3,

        /// <summary>
        /// All stimulation values
        /// </summary>
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_ResultType_StimulationValues))]
        StimulationValues = 4,

        #endregion

        #region Urology results (1001 - 2000)

        /// <summary>
        /// The average flow is the total voided volume divided by the flow time
        /// </summary>
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_ResultType_AverageFlowRate))]
        AverageFlowRate = 1001,

        /// <summary>
        /// Qmax is the maximum measured value of the flow during micturition
        /// </summary>
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_ResultType_Qmax))]
        Qmax = 1002,

        /// <summary>
        /// The time to Qmax is the elapsed time from the onset of the flow to the Qmax
        /// </summary>
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_ResultType_TimeToQmax))]
        TimeToQmax = 1003,

        /// <summary>
        /// The voided volume is the total volume expelled via the urethra
        /// </summary>
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_ResultType_VoidedVolume))]
        VoidedVolume = 1004,

        /// <summary>
        /// Total time from void start to void end
        /// </summary>
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_ResultType_VoidingTime))]
        VoidingTime = 1005,

        /// <summary>
        /// Time over which measurable flow actually occurs (where flow rate > 0.5 ml/s)
        /// </summary>
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_ResultType_FlowTime))]
        FlowTime = 1006,

        /// <summary>
        /// Time of relax till flow starts
        /// </summary>
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_ResultType_TimeRelaxTillFlowStarts))]
        TimeRelaxTillFlowStarts = 1007,

        /// <summary>
        /// The flow results
        /// </summary>
        FlowResults = 1008,

        /// <summary>
        /// The Booi shows the Bladder Outlet Obstruction index
        /// </summary>
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_ResultType_Booi))]
        Booi = 1009,

        /// <summary>
        /// The bci shows the Bladder Contractility Index
        /// </summary>
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_ResultType_Bci))]
        Bci = 1010,

        /// <summary>
        /// Pves at the maximum measured value of the flow during micturition. todo: Have one enum, remove copies with (US 87643)
        /// </summary>
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_ResultType_PVesQmax))]
        PVesQmax = 1011,
        PvesQMax = 1011,
        PvesQmax = 1011,

        /// <summary>
        /// Pdet at the maximum measured value of the flow during micturition
        /// </summary>
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_ResultType_PdetQmax))]
        PdetQmax = 1012,

        /// <summary>
        /// The hesitancy is the time in seconds from the moment the investigation is started until the patient started voiding
        /// </summary>
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_ResultType_Hesitancy))]
        Hesitancy = 1013,

        /// <summary>
        /// The corrected Qmax is the square root of the voiding volume
        /// </summary>
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_ResultType_CorrectedQmax))]
        CorrectedQmax = 1014,

        /// <summary>
        /// Pves max is the maximum bladder pressure (Pves) during the investigation (filling or voiding phase)
        /// </summary>
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_ResultType_PvesMax))]
        PvesMax = 1015,

        /// <summary>
        /// Pabd. max is the maximum pressure measured in the abdomen during the investigation filling or voiding phase.
        /// </summary>
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_ResultType_PabdMax))]
        PabdMax = 1016,

        /// <summary>
        /// Pdet max is the maximum detrusor pressure during the investigation filling or voiding phase.
        /// </summary>
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_ResultType_PdetMax))]
        PdetMax = 1017,

        /// <summary>
        /// Maximum urethral pressure
        /// </summary>
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_ResultType_PuraMax))]
        PuraMax = 1018,

        /// <summary>
        /// The PvesOpen
        /// </summary>
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_ResultType_PvesOpen))]
        PvesOpen = 1019,

        /// <summary>
        /// The PdetOpen
        /// </summary>
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_ResultType_PdetOpen))]
        PdetOpen = 1020,

        /// <summary>
        /// Pmuo is the lowest detrusor pressure during voiding
        /// </summary>
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_ResultType_Pmuo))]
        Pmuo = 1021,

        /// <summary>
        /// The closing pressure is the pressure at the termination of the flow in the voiding phase. i.e. the moment of the last droplet
        /// </summary>
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_ResultType_PdetClos))]
        PdetClos = 1022,

        /// <summary>
        /// Indicates if infused volume is applicable
        /// </summary>
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_ResultType_InfusedVolume))]
        InfusedVolume = 1023,

        /// <summary>
        /// Minimal pump speed
        /// </summary>
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_ResultType_PumpSpeedMin))]
        PumpSpeedMin = 1024,

        /// <summary>
        /// Maximal pump speed
        /// </summary>
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_ResultType_PumpSpeedMax))]
        PumpSpeedMax = 1025,

        /// <summary>
        /// The automatic puller speed as used during the investigation
        /// </summary>
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_ResultType_PullerSpeed))]
        PullerSpeed = 1026,

        /// <summary>
        /// Micturition resistance
        /// </summary>
        MicturitionResistance = 1027,

        /// <summary>
        /// Infused volume during the voiding phase
        /// </summary>
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_ResultType_ExtraInfusedVolume))]
        ExtraInfusedVolume = 1028,

        /// <summary>
        /// Filling of the bladder at the start of the filling phase
        /// </summary>
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_ResultType_BladderVolumeFillingPhaseStart))]
        BladderVolumeFillingPhaseStart = 1029,

        /// <summary>
        /// Filling of the bladder at the start of the voiding phase
        /// </summary>
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_ResultType_BladderVolumeVoidingPhaseStart))]
        BladderVolumeVoidingPhaseStart = 1030,

        /// <summary>
        /// Filling of the bladder at the end of the filling phase
        /// </summary>
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_ResultType_BladderVolumeFillingPhaseEnd))]
        BladderVolumeFillingPhaseEnd = 1031,

        /// <summary>
        /// Filling of the bladder at the end of the voiding phase
        /// </summary>
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_ResultType_BladderVolumeVoidingPhaseEnd))]
        BladderVolumeVoidingPhaseEnd = 1032,

        /// <summary>
        /// The leaked volume is the total volume expelled via the urethra in the filling phase
        /// </summary>
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_ResultType_VolumeLeaked))]
        VolumeLeaked = 1033,

        /// <summary>
        /// The total bladder capacity
        /// </summary>
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_ResultType_TotalBladderCapacity))]
        TotalBladderCapacity = 1034,

        /// <summary>
        /// Maximum urethral pressure within a profile phase
        /// </summary>
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_ResultType_Mup))]
        Mup = 1035,

        /// <summary>
        /// Maximum Urethral Closure Pressure within a profile phase
        /// </summary>
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_ResultType_Mucp))]
        Mucp = 1036,

        /// <summary>
        /// Table container to hold line containers
        /// </summary>
        TableContainer = 1037,

        // Line containers to hold all the results of a line of a table
        TableLineContainer = 1038,

        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_ResultType_Baseline))]
        BaseLinePressureLineContainer = 1039,

        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_ResultType_LeakPointPressure))]
        LeakPointPressureLineContainer = 1040,

        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_ResultType_PressureChange))]
        PressureChangeLineContainer = 1041,

        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_ResultType_Maximum))]
        MaximumPressureLineContainer = 1042,

        StressTestResults = 1043,

        LeakPointResults = 1044,

        ValsalvaResults = 1045,

        // Leak result tells if there was a leakp point in a certain period
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_ResultType_Leak))]
        Leak = 1046,

        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_ResultType_Delay))]
        Delay = 1047,

        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_ResultType_Volume))]
        Volume = 1048,

        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_ResultType_Pves))]
        Pves = 1049,

        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_ResultType_Pabd))]
        Pabd = 1050,

        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_ResultType_Pdet))]
        Pdet = 1051,

        /// <summary>
        /// Post Voided Residual value within a Flow or Voiding phase
        /// </summary>
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_ResultType_Pvr))]
        Pvr = 1056,

        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_ResultType_BladderVolume))]
        BladderVolume = 1057,

        /// <summary>
        /// Specific Gravity of Bladder at end of phase
        /// </summary>
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_ResultType_BladderSpecificGravity))]
        BladderSpecificGravity = 1058,

        /// <remarks>
        /// Each category of Nomogram result types needs to be in a separate region.
        /// Also specify the range of enum values in NomogramResults dictionary within the ResultTypeRanges class
        /// </remarks>
        #region Schafer Nomogram Results (1400-1449)

        SchaferNomogramResults = 1400,

        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_ResultType_Dampf))]
        Dampf = 1401,

        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_ResultType_OneOverC))]
        OneOverC = 1402,

        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_ResultType_A))]
        A = 1403,

        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_ResultType_BladderPowerClass))]
        BladderPowerClass = 1404,

        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_ResultType_BladderObstructionClass))]
        BladderObstructionClass = 1405,

        #endregion

        #region ICS Nomogram Results (1450 -1499)

        ICSNomogramResults = 1450,

        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_ResultType_AGValue))]
        AGValue = 1451,

        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_ResultType_ICSClassification))]
        ICSClassification = 1452,

        #endregion

        /// <summary>
        /// The total voided volume calculated per phase
        /// </summary>
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_ResultType_TotalVoidedVolume))]
        TotalVoidedVolume = 1060,

        #region Urology Profile results (1500-1600)

        /// <summary>
        /// Rest Profile event within a profile phase
        /// </summary>
        RestProfile = 1500,

        /// <summary>
        /// Stress Profile event within a profile phase
        /// </summary>
        StressProfile = 1501,

        Puller = 1510,

        /// <summary>
        /// Puller speed during the Profile Event
        /// </summary>
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_ResultType_PullerSpeed))]
        ProfilePullerSpeed = 1511,

        /// <summary>
        /// The puller distance during the Profile Event
        /// </summary>
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_ResultType_PullerDistance))]
        ProfilePullerDistance = 1512,

        /// <summary>
        /// Average Urethral Closure Pressure within a Rest/Stress profile event
        /// </summary>
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_ResultType_MeanPura))]
        MeanPura = 1515,

        /// <summary>
        /// Average PCLO within a Rest/Stress profile event
        /// </summary>
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_ResultType_MeanPclo))]
        MeanPclo = 1516,

        /// <summary>
        /// Value of PCLO at 30% of functional length within a Rest/Stress profile event
        /// </summary>
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_ResultType_PclosAt30))]
        PclosAt30 = 1517,

        /// <summary>
        /// Value of PCLO at 70% of functional length within a Rest/Stress profile event
        /// </summary>
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_ResultType_PclosAt70))]
        PclosAt70 = 1518,

        /// <summary>
        /// Percentage of functional length where MUP is measured
        /// </summary>
        PeakPuraPosition = 1519,

        FunctionalProfile = 1520,

        /// <summary>
        /// Infused volume at the start of the functional profile event
        /// </summary>
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_ResultType_ProfileInfusedVolume))]
        ProfileInfusedVolume = 1521,

        /// <summary>
        /// Urethra pressure at the position of the profile begin marker
        /// </summary>
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_ResultType_RestingBladderPressure))]
        ProfileRestingBladder = 1522,

        /// <summary>
        /// Maximum Urethral pressure during a Rest/Stress Profile interval
        /// </summary>
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_ResultType_ProfileMup))]
        ProfileMup = 1523,

        /// <summary>
        /// Maximum Urethral Closuer pressure during a Rest/Stress Profile interval
        /// </summary>
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_ResultType_ProfileMucp))]
        ProfileMucp = 1524,

        /// <summary>
        /// Length of the urethra, along which Pura exceeds Pves during a Rest/Stress Profile interval 
        /// </summary>
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_ResultType_FunctionalProfileLength))]
        FunctionalProfileLength = 1525,

        /// <summary>
        /// Length of the urethra, along which Pura exceeds 0 during a Rest/Stress Profile interval
        /// </summary>
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_ResultType_TotalProfileLength))]
        TotalProfileLength = 1526,

        /// <summary>
        /// For male, length of the urethra until the time where the MUCP is measured
        /// </summary>
        ProstaticLength = 1527,

        /// <summary>
        /// For female, length of the urethra until the time where the MUCP is measured
        /// </summary>
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_ResultType_UrethralContinenceZone))]
        UrethralContinenceZone = 1528,

        /// <summary>
        /// Area under the urethral pressure curve
        /// </summary>
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_ResultType_RestTotalProfileArea))]
        TotalProfileArea = 1529,

        /// <summary>
        /// Area under the urethral pressure curve between the Rest/Stress Profile start marker and the peak
        /// </summary>
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_ResultType_RestProximalAreaToPeak))]
        ProximalAreaToPeak = 1530,

        /// <summary>
        /// Area under the urethral pressure curve from the peak until the urethral pressure reaches 0
        /// </summary>
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_ResultType_RestDistalAreaAfterPeak))]
        DistalAreaAfterPeak = 1531,

        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_ResultType_ProfileProstaticOrUrethra))]
        ProfileProstaticOrUrethra = 1532,

        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_ResultType_ProfileRestingArea))]
        ProfileRestingArea = 1533,

        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_ResultType_StressProfileAverageTransmission))]
        ProfileAverageTransmission = 1534,

        /// <summary>
        /// Percentage of functional length where MUP is measured
        /// </summary>
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_ResultType_ProfileBladderFilling))]
        ProfileBladderFilling = 1535,

        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_ResultType_Transmission))]
        Transmission = 1540,

        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_ResultType_TransmissionBladderFilling))]
        TransmissionBladderFilling = 1541,

        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_ResultType_StressTransmissionPercentage))]
        TransmissionPercentage = 1542,

        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_ResultType_StressTransmissionDistance))]
        TransmissionDistance = 1543,

        #endregion

        #region Compliance results (1601-1700)

        /// <summary>
        /// Compliance event
        /// </summary>
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_ResultType_Compliance))]
        Compliance = 1601,

        /// <summary>
        /// Pdet at Compliance event start 
        /// </summary>
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_ResultType_Pdet_ComplianceStart))]
        Pdet_ComplianceStart = 1602,

        /// <summary>
        /// Pdet at Compliance event stop 
        /// </summary>
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_ResultType_Pdet_ComplianceStop))]
        Pdet_ComplianceStop = 1603,

        /// <summary>
        /// Infused volume at Compliance event start 
        /// </summary>
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_ResultType_InfusedVol_ComplianceStart))]
        InfusedVol_ComplianceStart = 1604,

        /// <summary>
        /// Infused volume at Compliance event stop
        /// </summary>
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_ResultType_InfusedVol_ComplianceStop))]
        InfusedVol_ComplianceStop = 1605,

        #endregion

        #endregion

        /// <remarks>
        /// Each category of Nomogram result types needs to be in a separate region.
        /// Also specify the range of enum values in NomogramResults dictionary within the ResultTypeRanges class
        /// </remarks>
        #region Liverpool Nomogram Results (1001, 1002, 1004, 1701-1749)

        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_ImageSubType_LiverpoolAverageFlowRateNomogram))]
        LiverpoolAverageFlowRateNomogram = 1701,

        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_ImageSubType_LiverpoolMaximumFlowRateNomogram))]
        LiverpoolMaximumFlowRateNomogram = 1702,

        #endregion

        #region Work and rest results (2001 - 3000)

        /// <summary>
        /// Phase mean channels value
        /// </summary>
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_ResultType_PhaseMeanChannelsValue))]
        PhaseMeanChannelsValue = 2001,

        /// <summary>
        /// Phase minimum channels value
        /// </summary>
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_ResultType_PhaseMinChannelsValue))]
        PhaseMinChannelsValue = 2002,

        /// <summary>
        /// Phase maximum channels value
        /// </summary>
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_ResultType_PhaseMaxChannelsValue))]
        PhaseMaxChannelsValue = 2003,

        /// <summary>
        /// Phase maximum channels value
        /// </summary>
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_ResultType_PhaseScoreChannelsValue))]
        PhaseScoreChannelsValue = 2004,

        /// <summary>
        /// Phase average on template
        /// </summary>
        PhaseAverageOnTemplate = 2005,

        /// <summary>
        /// The phase minimum maximum mean channels value
        /// </summary>
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_ResultType_PhaseMinMaxMeanChannelsValue))]
        PhaseMinMaxMeanChannelsValue = 2006,

        #endregion

        #region Overall results (3001 - 4000)

        /// <summary>
        /// Overall mean channels value
        /// </summary>
        OverallMeanChannelsValue = 3001,

        /// <summary>
        /// Overall minimum channels value
        /// </summary>
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_ResultType_OverallMinChannelsValue))]
        OverallMinChannelsValue = 3002,

        /// <summary>
        /// Overall maximum channels value
        /// </summary>
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_ResultType_OverallMaxChannelsValue))]
        OverallMaxChannelsValue = 3003,

        /// <summary>
        /// Overall average on template
        /// </summary>
        OverallAverageOnTemplate = 3004,

        /// <summary>
        /// Number of total phases planned
        /// </summary>
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_ResultType_TotalPhasesPlanned))]
        TotalPhasesPlanned = 3005,

        /// <summary>
        /// Number of total phases executed
        /// </summary>
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_ResultType_TotalPhasesExecuted))]
        TotalPhasesExecuted = 3006,

        /// <summary>
        /// The total phases planned and executed
        /// </summary>
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_ResultType_TotalPhasesPlannedAndExecuted))]
        TotalPhasesPlannedAndExecuted = 3007,

        #endregion

        #region Marker results (4001 - 5000)

        /// <summary>
        /// Result when marker was placed
        /// </summary>
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_ResultType_FatigueMarker))]
        FatigueMarker = 4001

        #endregion
    }

    /// <summary>
    /// Class defining the ranges of values in ResultType enum allocated for specific types of results. 
    /// </summary>
    /// <remarks>
    /// This class is used for easy look up of specific category of result types. The ranges defined within this class should be consistent with the regions in the ResultType enum.
    /// </remarks>
#pragma warning disable SA1649 // File name must match first type name
    public static class ResultTypeRanges
#pragma warning restore SA1649 // File name must match first type name
    {
        /// <summary>
        /// Dictionary defining the range of ResultType enum values allocated for each type of Nomograms. 
        /// </summary>
        /// <remarks>
        /// The tuple specifies the begin and end of the region of enum values
        /// </remarks>
#pragma warning disable SA1401 // Fields must be private
        public static Dictionary<ImageSubType, Tuple<int, int>> NomogramResults = new Dictionary<ImageSubType, Tuple<int, int>>
#pragma warning restore SA1401 // Fields must be private
        {
            { ImageSubType.SchaeferNomogram, new Tuple<int, int>(1400, 1449) },
            { ImageSubType.ICSNomogram, new Tuple<int, int>(1450, 1499) }
        };

#pragma warning disable SA1401 // Fields must be private
        public static Dictionary<ImageSubType, List<int>> LiverpoolNomogramResults = new Dictionary<ImageSubType, List<int>>
#pragma warning restore SA1401 // Fields must be private
            {
                { ImageSubType.LiverpoolMaximumFlowRateNomogram, new List<int>() { 1002, 1004, 1702 } },
                { ImageSubType.LiverpoolAverageFlowRateNomogram, new List<int>() { 1001, 1004, 1701 } }
            };

#pragma warning disable SA1401 // Fields must be private
        public static Dictionary<ImageSubType, List<int>> MiskolcNomogramResults = new Dictionary<ImageSubType, List<int>>
#pragma warning restore SA1401 // Fields must be private
        {
            { ImageSubType.MiskolcAverageFlowRateNomogram, new List<int>() { 1001, 1004 } },
            { ImageSubType.MiskolcMaximumFlowRateNomogram, new List<int>() { 1002, 1004 } }
        };
    }
}
