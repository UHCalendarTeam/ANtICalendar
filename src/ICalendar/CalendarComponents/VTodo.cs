using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ICalendar.ComponentProperties;
using ICalendar.GeneralInterfaces;

namespace ICalendar.CalendarComponents
{
    public class VTodo: CalendarComponent, IAlarmContainer
    {
        public VTodo()
        {
            Alarms = new List<VAlarm>();
        }

        public override string Name => "VTODO";

        public IList<VAlarm> Alarms { get; set; }

        /// <summary>
        /// If component is VAlarm type the add it to Alarms
        /// if not is a property and call the base
        /// </summary>
        /// <param name="component"></param>
        public override void AddItem(ICalendarObject component)
        {
            var comp = component as VAlarm;
            if (comp != null)
                Alarms.Add(comp);
            else
                base.AddItem(component);
        }
    }
}
