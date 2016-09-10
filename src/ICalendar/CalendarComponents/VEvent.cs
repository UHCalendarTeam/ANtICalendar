using System.Collections.Generic;
using ICalendar.GeneralInterfaces;

namespace ICalendar.CalendarComponents
{
    public class VEvent : CalendarComponent, ICalendarComponentsContainer
    {
        public VEvent()
        {
            CalendarComponents = new Dictionary<string, List<ICalendarComponent>>();
        }

        public override string Name => "VEVENT";

        /// <summary>
        ///     Contains the calendar components of the VEvent.
        ///     By general rule these components are just gonna be alarms.
        /// </summary>
        public Dictionary<string, List<ICalendarComponent>> CalendarComponents { get; }

        /// <summary>
        ///     Add an ICalendarComponent or IComponentProperty to the event.
        /// </summary>
        /// <param name="component"></param>
        public override void AddItem(ICalendarObject component)
        {
            var item = component as ICalendarComponent;
            if (item != null)
                if (CalendarComponents.ContainsKey(component.Name))
                    CalendarComponents[component.Name].Add(item);
                else
                    CalendarComponents.Add(item.Name, new List<ICalendarComponent> {item});
            else
                base.AddItem(component);
        }
    }
}