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
        public IList<ICalendarComponent> CalendarComponents { get; set; }

        public override string Name => "VTIMEZONE";       

        /// <summary>
        /// Add a subcomponent of the VTimeZone object or
        /// a property if component is IComponentProperty
        /// </summary>
        /// <param name="component"></param>
        public override void AddItem(object component)
        {
            var comp = component as ICalendarComponent;
            if (component != null)
                CalendarComponents.Add(comp);
            else
                 base.AddItem(component);
        }

    }
}
