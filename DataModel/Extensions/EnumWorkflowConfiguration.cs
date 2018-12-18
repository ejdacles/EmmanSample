// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Laborie">
//   Copyright (c) Laborie. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Laborie.Synergy.DataModel.Extensions
{
    using System.ComponentModel.DataAnnotations;
    using Translations;

    public enum EnumWorkflowConfiguration
    {
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_WorkflowConfiguration_FlowEMG))]
        FlowEMG,
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_WorkflowConfiguration_FlowEMGReport))]
        FlowEMGReport,

        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_WorkflowConfiguration_FlowWithEMG))]
        FlowWithEMG,
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_WorkflowConfiguration_FlowWithEmgReport))]
        FlowWithEMGReport,

        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_WorkflowConfiguration_FreeFlow))]
        FreeFlow,
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_WorkflowConfiguration_FreeFlowReport))]
        FreeFlowReport,

        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_WorkflowConfiguration_IceWaterTest))]
        IceWaterTest,
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_WorkflowConfiguration_IceWaterTestReport))]
        IceWaterTestReport,

        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_WorkflowConfiguration_IcewaterUrodynamics))]
        IcewaterUrodynamics,
        IcewaterUrodynamicsReport,

        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_WorkflowConfiguration_Pfr1Emg))]
        Pfr1Emg,
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_WorkflowConfiguration_Pfr1EmgReport))]
        Pfr1EmgReport,

        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_WorkflowConfiguration_Pfr1EmgAndPressure))]
        Pfr1EmgAndPressure,
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_WorkflowConfiguration_Pfr1EmgAndPressureReport))]
        Pfr1EmgAndPressureReport,

        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_WorkflowConfiguration_Pfr1Pressure))]
        Pfr1Pressure,
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_WorkflowConfiguration_Pfr1PressureReport))]
        Pfr1PressureReport,

        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_WorkflowConfiguration_Pfr2Emg))]
        Pfr2Emg,
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_WorkflowConfiguration_Pfr2EmgReport))]
        Pfr2EmgReport,

        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_WorkflowConfiguration_Pfr2EmgAndPressure))]
        Pfr2EmgAndPressure,
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_WorkflowConfiguration_Pfr2EmgAndPressureReport))]
        Pfr2EmgAndPressureReport,

        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_WorkflowConfiguration_PfrStimulation))]
        PfrStimulation,
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_WorkflowConfiguration_PfrStimulationReport))]
        PfrStimulationReport,

        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_WorkflowConfiguration_PressureFlow))]
        PressureFlow,
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_WorkflowConfiguration_PressureFlowReport))]
        PressureFlowReport,

        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_WorkflowConfiguration_UPP))]
        UPP,

        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_WorkflowConfiguration_UroFlow))]
        UroFlow,
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_WorkflowConfiguration_UroFlowReport))]
        UroFlowReport,

        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_WorkflowConfiguration_Urogynecology2PUrodynamics))]
        Urogynecology2PUrodynamics,
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_WorkflowConfiguration_Urogynecology2PUrodynamicsReport))]
        Urogynecology2PUrodynamicsReport,

        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_WorkflowConfiguration_Urogynecology3PUrodynamics))]
        Urogynecology3PUrodynamics,
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_WorkflowConfiguration_Urogynecology3PUrodynamicsReport))]
        Urogynecology3PUrodynamicsReport,

        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_WorkflowConfiguration_UrologyUrodynamics))]
        UrologyUrodynamics,
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_WorkflowConfiguration_UrologyUrodynamicsReport))]
        UrologyUrodynamicsReport,

        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_WorkflowConfiguration_VideoUrodynamics))]
        VideoUrodynamics,
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_WorkflowConfiguration_VideoUrodynamicsReport))]
        VideoUrodynamicsReport,

        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_WorkflowConfiguration_Qnr_AUASI))]
        Qnr_AUASI,

        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_WorkflowConfiguration_Qnr_BladderDiary))]
        Qnr_BladderDiary,

        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_WorkflowConfiguration_Qnr_ICIQ))]
        Qnr_ICIQ,

        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_WorkflowConfiguration_Qnr_ICS))]
        Qnr_ICS,

        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_WorkflowConfiguration_Qnr_ICS_Female))]
        Qnr_ICS_Female,

        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_WorkflowConfiguration_Qnr_ICS_Male))]
        Qnr_ICS_Male,

        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_WorkflowConfiguration_Qnr_IPSS))]
        Qnr_IPSS,

        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_WorkflowConfiguration_Qnr_PFR))]
        Qnr_PFR,

        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_WorkflowConfiguration_Qnr_PQOL))]
        Qnr_PQOL
    }
}
