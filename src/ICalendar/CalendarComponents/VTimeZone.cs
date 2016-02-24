using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ICalendar.ComponentProperties;
using ICalendar.GeneralInterfaces;

namespace ICalendar.CalendarComponents
{
    public class VTimezone:CalendarComponent, ICalendarComponentsContainer
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
                CalendarComponents.Add(comp.Name,new List<ICalendarComponent>() {comp});
            else
                 base.AddItem(component);
        }


       

    }
}
