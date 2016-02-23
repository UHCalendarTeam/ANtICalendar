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
    public class VEvent: CalendarComponent, IAlarmContainer
    {
        public VEvent()
        {
            Alarms = new List<VAlarm>();
        }
        public override string Name => "VEVENT";

        public IList<VAlarm> Alarms { get; set; }

        /// <summary>
        /// If component is VAlarm type the add it to Alarms
        /// if not is a property and call the base
        /// </summary>
        /// <param name="component"></param>
        public override void AddItem(object component)
        {
            var comp = component as VAlarm;
            if (comp != null)
                Alarms.Add(comp);
            else            
                base.AddItem(component);
        }

    }
}
