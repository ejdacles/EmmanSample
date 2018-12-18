// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Laborie">
//   Copyright (c) Laborie. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Laborie.Synergy.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Newtonsoft.Json;

    /// <summary>
    /// Extension to the Entity Framework auto generated GenerateReport class
    /// </summary>
    public partial class PhaseModel : IPhases, IPhaseAutoDetectPeakProperties, IPhaseAutoDetectProfileProperty
    {
        private const char VisibleChannelStringSeparator = ',';
        private const int DefaultRepeatCount = 1;
        private const int DefaultDuration = 0;
        private const int DefaultAfterFlowTime = 0;
        private const int DefaultCoundownTimerSeconds = 0;
        private const bool DefaultAcquireData = true;

        /// <summary>
        /// Gets or sets the visible channels displayed in the graphs
        /// </summary>
        public IList<int> VisibleChannels
        {
            get
            {
                if (string.IsNullOrEmpty(VisibleChannelsInternal))
                {
                    return Parent != null ? Parent.VisibleChannels : new List<int>();
                }

                return VisibleChannelsInternal.Split(VisibleChannelStringSeparator).Select(int.Parse).ToList();
            }

            set
            {
                VisibleChannelsInternal = string.Join(VisibleChannelStringSeparator.ToString(), value);
            }
        }

        /// <summary>
        /// Gets or sets the visible channels values displayed separately on the screen
        /// </summary>
        public IList<int> ChannelValuesShownSeparately
        {
            get
            {
                if (string.IsNullOrEmpty(ChannelValuesShownSeparatelyInternal))
                {
                    return Parent != null ? Parent.ChannelValuesShownSeparately : new List<int>();
                }

                return ChannelValuesShownSeparatelyInternal.Split(VisibleChannelStringSeparator).Select(int.Parse).ToList();
            }

            set
            {
                ChannelValuesShownSeparatelyInternal = string.Join(VisibleChannelStringSeparator.ToString(), value);
            }
        }

        public IList<AdditionalStatusBarItemType> ShowAdditionalStatusBarItems
        {
            get
            {
                if (string.IsNullOrEmpty(AdditionalStatusBarItems))
                {
                    return Parent != null ? Parent.ShowAdditionalStatusBarItems : new List<AdditionalStatusBarItemType>();
                }

                return AdditionalStatusBarItems.Split(VisibleChannelStringSeparator).Select(i => (AdditionalStatusBarItemType)Enum.Parse(typeof(AdditionalStatusBarItemType), i)).ToList(); 
            }

            set => AdditionalStatusBarItems = string.Join(VisibleChannelStringSeparator.ToString(), value.Cast<int>());
        }

        /// <summary>
        /// Gets or sets the events that have a scope defined
        /// </summary>
        public IList<EventType> EventScope
        {
            get
            {
                return string.IsNullOrEmpty(EventScopeInternal)
                    ? null
                    : EventScopeInternal.Split(VisibleChannelStringSeparator).Select(int.Parse).Cast<EventType>().ToList();
            }

            set
            {
                if (value == null)
                    value = new List<EventType>();

                EventScopeInternal = string.Join(VisibleChannelStringSeparator.ToString(), value.Cast<int>());
            }
        }

        /// <summary>
        /// Gets the parent phase
        /// </summary>
        public PhaseModel Parent => ParentPhase;

        /// <summary>
        /// Gets the child phases
        /// </summary>
        [JsonIgnore]
        public ICollection<PhaseModel> Phases => ChildPhases.OrderBy(p => p.PhaseOrder).ToList();

        /// <summary>
        /// Gets or sets the repeat count or the default when not set
        /// </summary>
        public int RepeatCount
        {
            get { return RepeatCountInternal ?? DefaultRepeatCount; }
            set { RepeatCountInternal = value; }
        }

        /// <summary>
        /// Gets or sets the duration in seconds or the default when not set
        /// </summary>
        public int DurationSeconds
        {
            get { return DurationSecondsInternal ?? DefaultAfterFlowTime; }
            set { DurationSecondsInternal = value; }
        }

        /// <summary>
        /// Gets or sets the After flow time in seconds or the default when not set
        /// </summary>
        public int AfterFlowTime
        {
            get { return AfterFlowTimeInternal ?? DefaultDuration; }
            set { AfterFlowTimeInternal = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether acquire data.
        /// </summary>
        public bool AcquireData
        {
            get { return AcquireDataInternal ?? DefaultAcquireData; }
            set { AcquireDataInternal = value; }
        }

        /// <summary>
        /// Gets or sets the countdown of the timer in seconds or the default value when not set
        /// </summary>
        public int CountdownTimerSeconds
        {
            get { return CountdownTimerSecondsInternal ?? DefaultCoundownTimerSeconds; }
            set { CountdownTimerSecondsInternal = value; }
        }

        /// <summary>
        /// The descendants of this instance.
        /// </summary>
        /// <returns>Returns the child</returns>
        public IEnumerable<PhaseModel> Descendants()
        {
            var children = new Stack<PhaseModel>(new[] { this });
            while (children.Any())
            {
                var child = children.Pop();
                yield return child;
                if (child.Phases == null) continue;
                foreach (var item in child.Phases) children.Push(item);
            }
        }
    }
}
