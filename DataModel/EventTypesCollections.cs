// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Laborie">
//   Copyright (c) Laborie. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Laborie.Synergy.DataModel
{
    using System.Collections.Generic;

    /// <summary>
    /// Event properties collections
    /// </summary>
    public static class EventTypesCollections
    {
        public static readonly List<EventType> ReParentEvents = new List<EventType>()
        {
            EventType.Pause,
            EventType.Artefact,
            EventType.Video,
            EventType.SingleImage,
            EventType.Cough,
            EventType.FixedText,
            EventType.CustomEvent,
            EventType.PauseWithoutMarker
        };

        public static readonly List<EventType> DeletableNonMovableEvents = new List<EventType>()
        {
            EventType.SingleImage,
            EventType.Video,
        };

        public static readonly List<EventType> NonDeletableChildEvents = new List<EventType>()
        {
            EventType.Profile,
            EventType.MUCP,
            EventType.MUP
        };

        public static readonly List<EventType> PhaseMovementUnrestrictedMarkers = new List<EventType>()
        {
            EventType.Pause,
            EventType.Video,
            EventType.SingleImage,
            EventType.Artefact,
            EventType.Cough,
            EventType.FixedText,
            EventType.CustomEvent
        };

        public static readonly List<EventType> SensationEvents = new List<EventType>()
        {
            EventType.FirstSensation,
            EventType.FirstDesire,
            EventType.StrongDesire,
            EventType.MaximumCystometricCapacity
        };

        /// <summary>
        /// Contains chained marker event types that are not allowed to delete in procedure unless they are closed (i.e. end time > begin time)
        /// </summary>
        public static readonly List<EventType> ProcedureNonDeletableOpenChainedMarkers = new List<EventType>
        {
            EventType.Flow,
            EventType.FlowArtifact
        };

        #region AutoFlowDetectionMarkerCorrection

        /// <summary>
        /// If an event on this list is detected in the FlowDetection phase transition it's time is corrected
        /// to match the pre-flow phase end
        /// </summary>
        public static readonly List<EventType> FlowAutoDetectionMarkerEndEvents = new List<EventType>
        {
            EventType.FirstSensation,
            EventType.FirstDesire,
            EventType.StrongDesire,
            EventType.MaximumCystometricCapacity,
            EventType.Valsalva,
            EventType.PermissionToVoid,
            EventType.EmgRelaxation,
            EventType.MUCP,
            EventType.StressProfile,
            EventType.RestProfile,
            EventType.Profile,
            EventType.MUP,
            EventType.Compliance,
            EventType.StressTest,
            EventType.SelectableText,
            EventType.FixedText,
            EventType.Artefact
        };

        /// <summary>
        /// If an event on this list is detected in the FlowDetection phase transition it will be re-partented to the
        /// voiding phase.
        /// </summary>
        public static readonly List<EventType> FlowAutoDetectionReParentEvents = new List<EventType>
        {
            EventType.SingleImage
        };
        #endregion

        public static readonly Dictionary<EventType, IList<EventType>> EventParentList = new Dictionary<EventType, IList<EventType>>
        {
            { EventType.Preview, new List<EventType> { EventType.PhaseEvent } },
            { EventType.Pause, new List<EventType> { EventType.PhaseEvent } },
            { EventType.LeakPointPressure, new List<EventType>() { EventType.PhaseEvent, EventType.StressTest, EventType.Valsalva } },
            { EventType.Valsalva, new List<EventType> { EventType.PhaseEvent } },
            { EventType.StressTest, new List<EventType> { EventType.PhaseEvent } },
            { EventType.Flow, new List<EventType> { EventType.PhaseEvent } },
            { EventType.FlowArtifact, new List<EventType> { EventType.PhaseEvent } },
            { EventType.FlowMaximum, new List<EventType> { EventType.Flow } },
            { EventType.PumpActive, new List<EventType> { EventType.PhaseEvent } },
            { EventType.PumpSpeed, new List<EventType> { EventType.PhaseEvent } },
            { EventType.PullerActive, new List<EventType> { EventType.PhaseEvent } },
            { EventType.PullerDistance, new List<EventType> { EventType.PullerActive } },
            { EventType.PullerReturn, new List<EventType> { EventType.PhaseEvent } },
            { EventType.StrongDesire, new List<EventType> { EventType.PhaseEvent } },
            { EventType.FirstDesire, new List<EventType> { EventType.PhaseEvent } },
            { EventType.FirstSensation, new List<EventType> { EventType.PhaseEvent } },
            { EventType.MaximumCystometricCapacity, new List<EventType> { EventType.PhaseEvent } },
            { EventType.CountDown, new List<EventType> { EventType.PhaseEvent } },
            { EventType.Fatigue, new List<EventType> { EventType.PhaseEvent } },
            { EventType.ChannelMaximum, new List<EventType> { EventType.PhaseEvent } },
            { EventType.ChannelMinimum, new List<EventType> { EventType.PhaseEvent } },
            { EventType.StimulationMaximum, new List<EventType> { EventType.PhaseEvent } },
            { EventType.PermissionToVoid, new List<EventType> { EventType.PhaseEvent } },
            { EventType.RestProfile, new List<EventType> { EventType.PhaseEvent } },
            { EventType.StressProfile, new List<EventType> { EventType.PhaseEvent } },
            { EventType.Profile, new List<EventType> { EventType.RestProfile, EventType.StressProfile } },
            { EventType.Transmission, new List<EventType> { EventType.Profile } },
            { EventType.MUCP, new List<EventType> { EventType.Profile } },
            { EventType.MUP, new List<EventType> { EventType.Profile } },
            { EventType.Artefact, new List<EventType> { EventType.PhaseEvent } },
            { EventType.MissingDataArtifact, new List<EventType> { EventType.PhaseEvent } },
            { EventType.Compliance, new List<EventType> { EventType.PhaseEvent } },
            { EventType.Cough, new List<EventType> { EventType.PhaseEvent, EventType.StressTest } },
            { EventType.EmgRelaxation, new List<EventType> { EventType.PhaseEvent } },
            { EventType.ZeroChannel, new List<EventType> { EventType.PhaseEvent } },
            { EventType.PhaseEvent, new List<EventType> { EventType.Root } },
            { EventType.CustomEvent, new List<EventType> { EventType.PhaseEvent } },
            { EventType.SelectableText, new List<EventType> { EventType.PhaseEvent } },
            { EventType.FixedText, new List<EventType> { EventType.PhaseEvent } },
            { EventType.SingleImage, new List<EventType> { EventType.PhaseEvent } },
            { EventType.Video, new List<EventType> { EventType.PhaseEvent } },
            { EventType.PvrInput, new List<EventType> { EventType.PhaseEvent } },
            { EventType.DeviceConnectionLost, new List<EventType> { EventType.PhaseEvent } },
            { EventType.InfusionBagSpecificGravityChange, new List<EventType> { EventType.PhaseEvent } },
            { EventType.BladderSpecificGravityOnPhaseEnter, new List<EventType> { EventType.PhaseEvent } },
            { EventType.PauseWithoutMarker, new List<EventType> { EventType.PhaseEvent } }
        };

        /// <summary>
        /// Gets event types to be added with their children
        /// </summary>
        /// <value>The event types to be added with their children.</value>
        public static readonly Dictionary<EventType, HashSet<EventType>> EventChildrenList =
            new Dictionary<EventType, HashSet<EventType>>
            {
                { EventType.Flow, new HashSet<EventType> { EventType.FlowMaximum } },
                { EventType.RestProfile, new HashSet<EventType> { EventType.Profile } },
                { EventType.StressProfile, new HashSet<EventType> { EventType.Profile } },
                { EventType.Profile, new HashSet<EventType> { EventType.MUCP, EventType.MUP } }
            };

        /// <summary>
        /// Gets the event types which don't need reparent during mouse drag and move.
        /// </summary>
        /// <value>The event types which don't need reparent during mouse drag and move.</value>
        public static HashSet<EventType> IgnoreReParentTypes { get; } = new HashSet<EventType> { EventType.Profile, EventType.MUCP, EventType.MUP };

        /// <summary>
        /// Gets the excluding event types.
        /// </summary>
        /// <value>The excluding event types.</value>
        public static List<EventType> ExcludingEventTypes { get; } = new List<EventType> { EventType.Preview, EventType.CountDown, EventType.Pause, EventType.PauseWithoutMarker };

        /// <summary>
        /// Gets the channel markers event types
        /// </summary>
        public static List<EventType> ChartChannelEventTypes { get; } = new List<EventType> { EventType.FlowMaximum, EventType.ChannelMaximum, EventType.ChannelMinimum, EventType.MissingDataArtifact };

        /// <summary>
        /// Gets the chart channel event types displayed at y axis.
        /// </summary>
        /// <value>
        /// The chart channel event types displayed at y value zero.</value>
        public static List<EventType> ChartChannelEventTypesDisplayedAtYAxis { get; } = new List<EventType> { EventType.MissingDataArtifact };

        /// <summary>
        /// Gets the un movable event types during review.
        /// </summary>
        /// <value>The un movable event types.</value>
        public static List<EventType> UnMovableEventTypesInReview { get; } = new List<EventType>
        {
            EventType.Pause,
            EventType.PumpActive,
            EventType.PullerActive,
            EventType.PullerReturn,
            EventType.SingleImage,
            EventType.Video,
            EventType.MissingDataArtifact,
            EventType.PauseWithoutMarker,
        };

        /// <summary>
        /// Gets the un movable event types during procedure.
        /// </summary>
        /// <value>The un movable event types.</value>
        public static List<EventType> UnMovableEventTypesInProcedure { get; } = new List<EventType>
        {
            EventType.Pause,
            EventType.PumpActive,
            EventType.PullerActive,
            EventType.PullerReturn,
            EventType.SingleImage,
            EventType.Video,
            EventType.MissingDataArtifact,
            EventType.PauseWithoutMarker,
            EventType.Artefact
        };

        /// <summary>
        /// Gets the hidden event types.
        /// </summary>
        /// <value>The hidden event types.</value>
        public static List<EventType> HiddenEventTypes { get; } = new List<EventType> { EventType.Preview, EventType.CountDown, EventType.PumpSpeed, EventType.PvrInput, EventType.BladderSpecificGravityOnPhaseEnter, EventType.PauseWithoutMarker };

        /// <summary>
        /// Gets the event types that are not allowed to delete in online review - doesn't contain ones that also cannot be deleted in review.
        /// </summary>
        /// <value>The peak detection event types.</value>
        public static List<EventType> OnlineReviewNonDeletableEventTypes { get; } = new List<EventType> { EventType.FirstSensation, EventType.FirstDesire, EventType.StrongDesire, EventType.MaximumCystometricCapacity };

        /// <summary>
        /// Gets the event types that are not allowed to delete in  review - doesn't contain ones that also cannot be deleted in online review.
        /// </summary>
        /// <value>The peak detection event types.</value>
        public static HashSet<EventType> ReviewNonDeletableEventTypes { get; } = new HashSet<EventType> { EventType.Profile, EventType.MUCP, EventType.MUP };

        /// <summary>
        /// Gets the peak detection event types.
        /// </summary>
        /// <value>The peak detection event types.</value>
        public static List<EventType> PeakDetectionEventTypes { get; } = new List<EventType> { EventType.Cough, EventType.Transmission };

        /// <summary>
        /// Gets the flow delay affected event types.
        /// </summary>
        /// <value>
        /// The flow delay affected event types.
        /// </value>
        public static List<EventType> FlowDelayAffectedEventTypes { get; } = new List<EventType>
        {
            EventType.ChannelMaximum,
            EventType.ChannelMinimum,
        };

        /// <summary>
        /// Gets the event types which are represented with 2 markers in the chart.
        /// </summary>
        /// <value>The event types where begin and end times are displayed with separate markers.</value>
        public static HashSet<EventType> DisplayEventAsChainedMarkersTypes { get; } = new HashSet<EventType>
        {
            EventType.StressTest, EventType.PumpActive, EventType.Valsalva, EventType.PullerActive, EventType.PullerReturn,
            EventType.Flow, EventType.FlowArtifact, EventType.RestProfile, EventType.StressProfile,
            EventType.Cough, EventType.Profile, EventType.Transmission, EventType.Compliance, EventType.Video,
            EventType.Artefact, EventType.MissingDataArtifact
        };

        /// <summary>
        /// Gets the event types which are represent device hardware events functionality.
        /// </summary>
        /// <value>The event types where begin and end times are displayed when hardware devices change its functional statuses.</value>
        public static List<EventType> SupportedDevicesEventTypes { get; } = new List<EventType>
        {
            // TODO: Review the name of the property and decide whether we should add other event types before we actually use them, for instance PullerActive
            EventType.PumpActive
        };

        /// <summary>
        /// Returns a list of supported event types based on the specified phase model type
        /// </summary>
        /// <param name="phaseModelType">The phase model type enum</param>
        /// <returns>A list of event types that are allowed to be placed in the specified phase model type</returns>
        public static IList<EventType> GetSupportedEventTypesForAPhaseType(PhaseModelTypes phaseModelType)
        {
            var supportedEventTypes = new List<EventType> { EventType.Artefact };
            supportedEventTypes.Add(EventType.DeviceConnectionLost);
            switch (phaseModelType)
            {
                case PhaseModelTypes.Fillingphase:
                    supportedEventTypes.Add(EventType.Cough);
                    supportedEventTypes.Add(EventType.StressTest);
                    supportedEventTypes.Add(EventType.LeakPointPressure);
                    supportedEventTypes.Add(EventType.Valsalva);
                    supportedEventTypes.Add(EventType.FirstSensation);
                    supportedEventTypes.Add(EventType.FirstDesire);
                    supportedEventTypes.Add(EventType.StrongDesire);
                    supportedEventTypes.Add(EventType.MaximumCystometricCapacity);
                    supportedEventTypes.Add(EventType.RestProfile);
                    supportedEventTypes.Add(EventType.StressProfile);
                    supportedEventTypes.Add(EventType.Transmission);
                    supportedEventTypes.Add(EventType.Profile);
                    supportedEventTypes.Add(EventType.MUP);
                    supportedEventTypes.Add(EventType.MUCP);
                    supportedEventTypes.Add(EventType.Compliance);
                    supportedEventTypes.Add(EventType.CustomEvent);
                    break;
                case PhaseModelTypes.FlowPhase:
                    supportedEventTypes.Add(EventType.Cough);
                    supportedEventTypes.Add(EventType.Flow);
                    supportedEventTypes.Add(EventType.PermissionToVoid);
                    supportedEventTypes.Add(EventType.CustomEvent);
                    supportedEventTypes.Add(EventType.FlowArtifact);
                    break;
                case PhaseModelTypes.RestPhase:
                case PhaseModelTypes.WorkPhase:
                    supportedEventTypes.Add(EventType.Fatigue);
                    break;
                case PhaseModelTypes.StimulationPhase:
                    break;
                case PhaseModelTypes.VoidingPhase:
                    supportedEventTypes.Add(EventType.Cough);
                    supportedEventTypes.Add(EventType.Flow);
                    supportedEventTypes.Add(EventType.PermissionToVoid);
                    supportedEventTypes.Add(EventType.EmgRelaxation);
                    supportedEventTypes.Add(EventType.CustomEvent);
                    supportedEventTypes.Add(EventType.FlowArtifact);
                    break;
                case PhaseModelTypes.ProfilePhase:
                    supportedEventTypes.Add(EventType.RestProfile);
                    supportedEventTypes.Add(EventType.StressProfile);
                    supportedEventTypes.Add(EventType.Cough);
                    supportedEventTypes.Add(EventType.Transmission);
                    supportedEventTypes.Add(EventType.Profile);
                    supportedEventTypes.Add(EventType.MUP);
                    supportedEventTypes.Add(EventType.MUCP);
                    supportedEventTypes.Add(EventType.PullerActive);
                    supportedEventTypes.Add(EventType.PullerReturn);
                    supportedEventTypes.Add(EventType.CustomEvent);
                    break;
            }

            return supportedEventTypes;
        }

        /// <summary>
        /// Gets the type of the supported artefacts types by channel.
        /// </summary>
        /// <param name="channelType">Type of the channel.</param>
        /// <returns>A list of supported artefacts types based on channel type</returns>
        public static List<EventType> GetSupportedArtefactsTypesByChannelType(ChannelType channelType)
        {
            var artefactTypes = new List<EventType>();

            switch (channelType)
            {
                case ChannelType.Flow:
                    artefactTypes.Add(EventType.FlowArtifact);
                    artefactTypes.Add(EventType.MissingDataArtifact);
                    break;
                case ChannelType.Pves:
                case ChannelType.Pura:
                case ChannelType.Pabd:
                case ChannelType.Pclos:
                case ChannelType.Pdet:
                case ChannelType.P4:
                case ChannelType.Pressure:
                    artefactTypes.Add(EventType.Artefact);
                    artefactTypes.Add(EventType.Cough);
                    artefactTypes.Add(EventType.MissingDataArtifact);
                    break;
                default:
                    artefactTypes.Add(EventType.MissingDataArtifact);
                    break;
            }

            return artefactTypes;
        }

        /// <summary>
        /// Gets the type of the supported chained marker artefacts types by channel.
        /// </summary>
        /// <param name="channelType">Type of the channel.</param>
        /// <param name="chainedMarkerEventType">Type of the chained marker event.</param>
        /// <returns>A list of supported artefacts types based on the chained marker event type and channel type</returns>
        public static List<EventType> GetSupportedChainedMarkerArtefactsTypesByChannelType(ChannelType channelType, EventType chainedMarkerEventType)
        {
            var artefactTypes = GetSupportedArtefactsTypesByChannelType(channelType);

            switch (chainedMarkerEventType)
            {
                case EventType.Cough:
                    artefactTypes.Remove(EventType.Cough);
                    artefactTypes.Remove(EventType.Artefact);
                    artefactTypes.Add(EventType.MissingDataArtifact);
                    break;
            }

            return artefactTypes;
        }
    }
}
