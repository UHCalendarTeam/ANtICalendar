using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICalendar.ComponentProperties;
using ICalendar.GeneralInterfaces;

namespace ICalendar.CalendarComponents
{
    public class VEvent: CalendarComponent, ICalendarComponentsContainer
    {
        public VEvent()
        {
            CalendarComponents = new Dictionary<string, IList<ICalendarComponent>>();
        }
        public override string Name => "VEVENT";

       

        /// <summary>
        /// If component is VAlarm type the add it to Alarms
        /// if not is a property and call the base
        /// </summary>
        /// <param name="component"></param>
        public override void AddItem(ICalendarObject component)
        {
            var item = component as ICalendarComponent;
            if(item != null)
                if(CalendarComponents.ContainsKey(component.Name))
                    CalendarComponents[component.Name].Add(item);
                else
                    CalendarComponents.Add(item.Name, new List<ICalendarComponent>() {item});        
            else
                base.AddItem(component);
        }

        public IDictionary<string, IList<ICalendarComponent>> CalendarComponents { get; }
    }
}
