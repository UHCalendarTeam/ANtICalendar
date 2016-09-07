using ICalendar.GeneralInterfaces;
using System.Collections.Generic;

namespace ICalendar.CalendarComponents
{
    public class VTimezone : CalendarComponent, ICalendarComponentsContainer
    {
        public VTimezone()
        {
            CalendarComponents = new Dictionary<string, IList<ICalendarComponent>>();
        }

        public override string Name => "VTIMEZONE";

        public IDictionary<string, IList<ICalendarComponent>> CalendarComponents { get; }

        /// <summary>
        /// Add a subcomponent of the VTimeZone object or
        /// a property if component is IComponentProperty
        /// </summary>
        /// <param name="component"></param>
        public override void AddItem(ICalendarObject component)
        {
            var comp = component as ICalendarComponent;
            if (comp != null)
                if (CalendarComponents.ContainsKey(comp.Name))
                    CalendarComponents[comp.Name].Add(comp);
                else
                    CalendarComponents.Add(comp.Name, new List<ICalendarComponent>() { comp });
            else
                base.AddItem(component);
        }
    }
}