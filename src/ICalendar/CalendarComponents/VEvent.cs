using ICalendar.GeneralInterfaces;
using System.Collections.Generic;

namespace ICalendar.CalendarComponents
{
    public class VEvent : CalendarComponent, ICalendarComponentsContainer
    {
        public VEvent()
        {
            CalendarComponents = new Dictionary<string, IList<ICalendarComponent>>();
        }

        public override string Name => "VEVENT";

        /// <summary>
        /// Add an ICalendarComponent to the event
        /// or a property.
        /// </summary>
        /// <param name="component"></param>
        public override void AddItem(ICalendarObject component)
        {
            var item = component as ICalendarComponent;
            if (item != null)
                if (CalendarComponents.ContainsKey(component.Name))
                    CalendarComponents[component.Name].Add(item);
                else
                    CalendarComponents.Add(item.Name, new List<ICalendarComponent>() { item });
            else
                base.AddItem(component);
        }

        /// <summary>
        /// Contains the components of the VEvent (i.e
        /// </summary>
        public IDictionary<string, IList<ICalendarComponent>> CalendarComponents { get; }
    }
}