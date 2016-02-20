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

        public VAlarm EventAlarm { get; set; }

        public IList<VAlarm> Alarms { get; set; }

      }
}
