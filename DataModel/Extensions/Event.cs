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

    using Common;

    /// <summary>
    /// Expansion of the event.
    /// </summary>
    public partial class Event
    {
        /// <summary>
        /// Gets or sets the display name of the event.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the virtual begin time.
        /// </summary>
        public long ViewBeginTime { get; set; }

        /// <summary>
        /// Gets or sets the virtual end time.
        /// </summary>
        public long ViewEndTime { get; set; }

        public bool CloseEvent { get; set; }

        /// <summary>
        /// Gets or sets the exclude periods.
        /// </summary>
        public List<Tuple<long, long>> ExcludePeriods { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether a marker must be shown
        /// </summary>
        /// <value><c>true</c> if [show marker]; otherwise, <c>false</c>.</value>
        public bool Visible { get; set; }

        /// <summary>
        /// Gets or sets the planned property, only used in container events
        /// </summary>
        public int RepeatsPlanned { get; set; }

        /// <summary>
        /// Gets or sets custom text marker in review
        /// </summary>
        public string ReviewCustomTextMarker { get; set; }

        /// <summary>
        /// Gets a value indicating whether 2 separate markers should be displayed for the event (such as Valsalva)
        /// </summary>
        public bool DisplayAsChainedMarkers => EventTypesCollections.DisplayEventAsChainedMarkersTypes.Contains(Event_Type);

        /// <summary>
        /// Gets a value indicating whether this event can be moved during review or procedure.
        /// </summary>
        /// <param name="review">Indicate if it is in review or procedure</param>
        /// <returns><c>true</c> if [marker can be move]; otherwise, <c>false</c></returns>
        public bool CanBeMove(bool review)
        {
            if (review)
            {
                return !EventTypesCollections.UnMovableEventTypesInReview.Contains(Event_Type);
            }

            return !EventTypesCollections.UnMovableEventTypesInProcedure.Contains(Event_Type);
        }

        public IEnumerable<Event> GetAllEvents()
        {
            yield return this;

            foreach (var child in Children)
            {
                foreach (var childEvent in child.GetAllEvents())
                {
                    yield return childEvent;
                }
            }
        }

        public IEnumerable<Result> GetAllResults()
        {
            foreach (var result in Results)
            {
                yield return result;
            }

            foreach (var child in Children)
            {
                foreach (var childEvent in child.GetAllEvents())
                {
                    foreach (var result in childEvent.Results)
                    {
                        yield return result;
                    }
                }
            }
        }

        public PhaseEvent GetPhase()
        {
            if (Event_Type == EventType.PhaseEvent)
                return this as PhaseEvent;

            if (Parent.Event_Type == EventType.Root)
            {
                return Parent.Children.Where(e => e is PhaseEvent).OrderBy(x => x.BeginTime).Reverse().FirstOrDefault(x => x.BeginTime <= BeginTime && x.EndTime > EndTime) as PhaseEvent;
            }

            var parentEvent = Parent;
            while (parentEvent.Event_Type != EventType.PhaseEvent)
            {
                parentEvent = parentEvent.Parent;
            }

            return parentEvent as PhaseEvent;
        }

        /// <summary>
        /// Localizes the <c>DisplayName</c> if the <c>Name</c> is equal to <c>Event_Type.ToString()</c>
        /// </summary>
        public void TranslateDisplayName()
        {
            var noTranslationNeeded = Name != Event_Type.ToString();

            DisplayName = noTranslationNeeded ? Name : EnumDescriptionConverter.EnumToString(Event_Type);
        }
    }
}
