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
    public class VEvent: CalendarComponent
    {
        public override string Name => "VEVENT";

        public List<VAlarm> Alarms { get; set; }
     
    }
}
