using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ICalendar.ComponentProperties;
using ICalendar.GeneralInterfaces;

namespace ICalendar.CalendarComponents
{
    public class VTodo: CalendarComponent, ICalendarComponentsContainer
    {
        public VTodo()
        {
            CalendarComponents = new Dictionary<string, IList<ICalendarComponent>>();
        }

        public override string Name => "VTODO";
        public IDictionary<string, IList<ICalendarComponent>> CalendarComponents { get; }


        /// <summary>
        /// If component is VAlarm type the add it to Alarms
        /// if not is a property and call the base
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

       
    }
}
