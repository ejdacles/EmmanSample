// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Laborie">
//   Copyright (c) Laborie. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Laborie.Synergy.DataModel
{
    using System;

    using Common;
    using Translations;

    /// <summary>
    /// The ResultHelper class
    /// </summary>
    public class ResultsHelper
    {
        /// <summary>
        /// Gets the friendly name of the result, to be displayed to the user.
        /// </summary>
        /// <param name="res">The result to be converted</param>
        /// <returns>User friendly name of result</returns>
        public static string GetResultFriendlyName(Result res)
        {
            // Switch statement is for the results that are used by various events and require a 
            // different name based off of the particular event type it is associated to
            switch (res.ResultType)
            {
                case ResultTypes.PvesMax:
                    if (res.Event.Name.Contains("Flow"))
                    {
                        return Language.Enum_ResultType_FlowPvesMax;
                    }
                    else if (res.Event.Name.Contains("Voiding"))
                    {
                        return Language.Enum_ResultType_VoidingPvesMax;
                    }
                    else if (res.Event.Name.Contains("Filling"))
                    {
                        return Language.Enum_ResultType_FillingPvesMax;
                    }

                    break;

                case ResultTypes.PabdMax:
                    if (res.Event.Name.Contains("Flow"))
                    {
                        return Language.Enum_ResultType_FlowPabdMax;
                    }
                    else if (res.Event.Name.Contains("Voiding"))
                    {
                        return Language.Enum_ResultType_VoidingPabdMax;
                    }
                    else if (res.Event.Name.Contains("Filling"))
                    {
                        return Language.Enum_ResultType_FillingPabdMax;
                    }

                    break;

                case ResultTypes.PdetMax:
                    if (res.Event.Name.Contains("Flow"))
                    {
                        return Language.Enum_ResultType_FlowPdetMax;
                    }
                    else if (res.Event.Name.Contains("Voiding"))
                    {
                        return Language.Enum_ResultType_VoidingPdetMax;
                    }
                    else if (res.Event.Name.Contains("Filling"))
                    {
                        return Language.Enum_ResultType_FillingPdetMax;
                    }

                    break;

                case ResultTypes.PuraMax:
                    if (res.Event.Name.Contains("Flow"))
                    {
                        return Language.Enum_ResultType_FlowPuraMax;
                    }
                    else if (res.Event.Name.Contains("Voiding"))
                    {
                        return Language.Enum_ResultType_VoidingPuraMax;
                    }
                    else if (res.Event.Name.Contains("Filling"))
                    {
                        return Language.Enum_ResultType_FillingPuraMax;
                    }

                    break;

                case ResultTypes.Leak:
                    if (res.Event.Event_Type == EventType.Cough ||
                        (res.Event.Event_Type == EventType.LeakPointPressure && res.Event.Parent.Event_Type != EventType.Valsalva))
                    {
                        return Language.Enum_ResultType_CoughLeak;
                    }
                    else if (res.Event.Event_Type == EventType.Valsalva ||
                             (res.Event.Event_Type == EventType.LeakPointPressure && res.Event.Parent.Event_Type == EventType.Valsalva))
                    {
                        return Language.Enum_ResultType_ValsalvaLeak;
                    }

                    break;

                case ResultTypes.Volume:
                    if (res.Event.Event_Type == EventType.Cough)
                    {
                        return Language.Enum_ResultType_CoughVolume;
                    }
                    else if (res.Event.Event_Type == EventType.Valsalva ||
                             (res.Event.Event_Type == EventType.LeakPointPressure && res.Event.Parent.Event_Type == EventType.Valsalva))
                    {
                        return Language.Enum_ResultType_ValsalvaVolume;
                    }
                    else if (res.Event.Event_Type == EventType.LeakPointPressure)
                    {
                        return Language.Enum_ResultType_LeakPointPressureVolume;
                    }

                    break;

                case ResultTypes.Pves:
                    if (res.Event.Event_Type == EventType.Cough)
                    {
                        return Language.Enum_ResultType_CoughPves;
                    }
                    else if (res.Event.Event_Type == EventType.LeakPointPressure && res.Event.Parent.Event_Type != EventType.Valsalva)
                    {
                        return Language.Enum_ResultType_LeakPointPressurePves;
                    }

                    break;

                case ResultTypes.Pdet:
                    if (res.Event.Event_Type == EventType.Cough)
                    {
                        return Language.Enum_ResultType_CoughPdet;
                    }
                    else if (res.Event.Event_Type == EventType.LeakPointPressure && res.Event.Parent.Event_Type != EventType.Valsalva)
                    {
                        return Language.Enum_ResultType_LeakPointPressurePdet;
                    }

                    break;

                case ResultTypes.Pabd:
                    if (res.Event.Event_Type == EventType.Cough)
                    {
                        return Language.Enum_ResultType_CoughPabd;
                    }
                    else if (res.Event.Event_Type == EventType.LeakPointPressure && res.Event.Parent.Event_Type != EventType.Valsalva)
                    {
                        return Language.Enum_ResultType_LeakPointPressurePabd;
                    }

                    break;

                case ResultTypes.BaseLinePressureLineContainer:
                    if (res.Event.Event_Type == EventType.Valsalva ||
                        (res.Event.Event_Type == EventType.LeakPointPressure && res.Event.Parent.Event_Type == EventType.Valsalva))
                    {
                        return Language.Enum_ResultType_ValsalvaBaseLinePressure;
                    }

                    break;

                case ResultTypes.LeakPointPressureLineContainer:
                    if (res.Event.Event_Type == EventType.Valsalva ||
                        (res.Event.Event_Type == EventType.LeakPointPressure && res.Event.Parent.Event_Type == EventType.Valsalva))
                    {
                        return Language.Enum_ResultType_ValsalvaLeakPointPressure;
                    }

                    break;

                case ResultTypes.PressureChangeLineContainer:
                    if (res.Event.Event_Type == EventType.Valsalva)
                    {
                        return Language.Enum_ResultType_ValsalvaPressureChange;
                    }
                    else if (res.Event.Event_Type == EventType.LeakPointPressure && res.Event.Parent.Event_Type == EventType.Valsalva)
                    {
                        return Language.Enum_ResultType_ValsalvaLeakPointPressureChange;
                    }

                    break;

                case ResultTypes.MaximumPressureLineContainer:
                    if (res.Event.Event_Type == EventType.Valsalva ||
                        (res.Event.Event_Type == EventType.LeakPointPressure && res.Event.Parent.Event_Type == EventType.Valsalva))
                    {
                        return Language.Enum_ResultType_ValsalvaMaximumPressure;
                    }

                    break;
                case ResultTypes.ProfileMup:
                    if (res.Event.Event_Type == EventType.RestProfile ||
                        (res.Event.Event_Type == EventType.Profile && res.Event.Parent.Event_Type == EventType.RestProfile))
                    {
                        return Language.Enum_ResultType_RestProfileMup;
                    }
                    else if (res.Event.Event_Type == EventType.StressProfile ||
                             (res.Event.Event_Type == EventType.Profile && res.Event.Parent.Event_Type == EventType.StressProfile))
                    {
                        return Language.Enum_ResultType_StressProfileMup;
                    }

                    break;
                case ResultTypes.ProfileMucp:
                    if (res.Event.Event_Type == EventType.RestProfile ||
                        (res.Event.Event_Type == EventType.Profile && res.Event.Parent.Event_Type == EventType.RestProfile))
                    {
                        return Language.Enum_ResultType_RestProfileMucp;
                    }
                    else if (res.Event.Event_Type == EventType.StressProfile ||
                             (res.Event.Event_Type == EventType.Profile && res.Event.Parent.Event_Type == EventType.StressProfile))
                    {
                        return Language.Enum_ResultType_StressProfileMucp;
                    }

                    break;

                case ResultTypes.BladderVolume:
                    if (res.Event.Event_Type == EventType.FirstSensation)
                    {
                        return Language.Enum_ResultType_FirstSensationBladderVolume;
                    }
                    else if (res.Event.Event_Type == EventType.FirstDesire)
                    {
                        return Language.Enum_ResultType_FirstDesireBladderVolume;
                    }
                    else if (res.Event.Event_Type == EventType.StrongDesire)
                    {
                        return Language.Enum_ResultType_StrongDesireBladderVolume;
                    }
                    else if (res.Event.Event_Type == EventType.MaximumCystometricCapacity)
                    {
                        return Language.Enum_ResultType_MaxCapacityBladderVolume;
                    }

                    break;

                case ResultTypes.FunctionalProfileLength:
                    if (res.Event.Event_Type == EventType.RestProfile ||
                        (res.Event.Event_Type == EventType.Profile && res.Event.Parent.Event_Type == EventType.RestProfile))
                    {
                        return Language.Enum_ResultType_RestFunctionalProfileLength;
                    }
                    else if (res.Event.Event_Type == EventType.StressProfile ||
                             (res.Event.Event_Type == EventType.Profile && res.Event.Parent.Event_Type == EventType.StressProfile))
                    {
                        return Language.Enum_ResultType_StressFunctionalProfileLength;
                    }

                    break;

                case ResultTypes.TotalProfileLength:
                    if (res.Event.Event_Type == EventType.RestProfile ||
                        (res.Event.Event_Type == EventType.Profile && res.Event.Parent.Event_Type == EventType.RestProfile))
                    {
                        return Language.Enum_ResultType_RestTotalProfileLength;
                    }
                    else if (res.Event.Event_Type == EventType.StressProfile ||
                             (res.Event.Event_Type == EventType.Profile && res.Event.Parent.Event_Type == EventType.StressProfile))
                    {
                        return Language.Enum_ResultType_StressTotalProfileLength;
                    }

                    break;

                case ResultTypes.ProfileInfusedVolume:
                    if (res.Event.Event_Type == EventType.RestProfile ||
                        (res.Event.Event_Type == EventType.Profile && res.Event.Parent.Event_Type == EventType.RestProfile))
                    {
                        return Language.Enum_ResultType_RestProfileInfusedVolume;
                    }
                    else if (res.Event.Event_Type == EventType.StressProfile ||
                             (res.Event.Event_Type == EventType.Profile && res.Event.Parent.Event_Type == EventType.StressProfile))
                    {
                        return Language.Enum_ResultType_StressProfileInfusedVolume;
                    }

                    break;

                case ResultTypes.ProfileRestingBladder:
                    if (res.Event.Event_Type == EventType.RestProfile ||
                        (res.Event.Event_Type == EventType.Profile && res.Event.Parent.Event_Type == EventType.RestProfile))
                    {
                        return Language.Enum_ResultType_RestingBladderPressure;
                    }
                    else if (res.Event.Event_Type == EventType.StressProfile ||
                             (res.Event.Event_Type == EventType.Profile && res.Event.Parent.Event_Type == EventType.StressProfile))
                    {
                        return Language.Enum_ResultType_StressRestingBladderPressure;
                    }

                    break;

                case ResultTypes.ProfileBladderFilling:
                    if (res.Event.Event_Type == EventType.StressProfile ||
                        (res.Event.Event_Type == EventType.Profile && res.Event.Parent.Event_Type == EventType.StressProfile))
                    {
                        return Language.Enum_ResultType_ProfileBladderFilling;
                    }

                    break;

                default:
                    break;
            }

            // If this result type is only used by one event, it will take the DisplayAttribute
            // that is assigned to the enum
            return EnumDescriptionConverter.EnumToString(res.ResultType);
        }

        /// <summary>
        /// Gets the friendly name of the result that is represented in table format in the database.
        /// </summary>
        /// <param name="resColumn">The result type of the table column</param>
        /// <param name="resRow">The result type of the table row</param>
        /// <returns>User friendly name of result</returns>
        public static string GetFriendlyNameOfTableResult(Result resColumn, ResultTypes resRow)
        {
            if (resRow == ResultTypes.MaximumPressureLineContainer)
            {
                if (resColumn.Event.Event_Type == EventType.Valsalva ||
                    (resColumn.Event.Event_Type == EventType.LeakPointPressure && resColumn.Event.Parent.Event_Type == EventType.Valsalva))
                {
                    switch (resColumn.ResultType)
                    {
                        case ResultTypes.Pves:
                            return Language.Enum_ResultType_ValsalvaMaxPves;

                        case ResultTypes.Pdet:
                            return Language.Enum_ResultType_ValsalvaMaxPdet;

                        case ResultTypes.Pabd:
                            return Language.Enum_ResultType_ValsalvaMaxPabd;
                    }
                }
            }
            else if (resRow == ResultTypes.LeakPointPressureLineContainer)
            {
                if (resColumn.Event.Event_Type == EventType.Valsalva || 
                    (resColumn.Event.Event_Type == EventType.LeakPointPressure && resColumn.Event.Parent.Event_Type == EventType.Valsalva))
                {
                    switch (resColumn.ResultType)
                    {
                        case ResultTypes.Pves:
                            return Language.Enum_ResultType_ValsalvaLeakPointPressurePves;

                        case ResultTypes.Pdet:
                            return Language.Enum_ResultType_ValsalvaLeakPointPressurePdet;

                        case ResultTypes.Pabd:
                            return Language.Enum_ResultType_ValsalvaLeakPointPressurePabd;
                    }
                }
                else if (resColumn.Event.Event_Type == EventType.LeakPointPressure && resColumn.Event.Parent.Event_Type != EventType.Valsalva)
                {
                    switch (resColumn.ResultType)
                    {
                        case ResultTypes.Pves:
                            return Language.Enum_ResultType_LeakPointPressurePves;

                        case ResultTypes.Pdet:
                            return Language.Enum_ResultType_LeakPointPressurePdet;

                        case ResultTypes.Pabd:
                            return Language.Enum_ResultType_LeakPointPressurePabd;
                    }
                }
            }

            return GetResultFriendlyName(resColumn);
        }
    }
}