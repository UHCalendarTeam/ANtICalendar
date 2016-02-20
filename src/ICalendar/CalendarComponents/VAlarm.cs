using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ICalendar.ComponentProperties;
using ICalendar.GeneralInterfaces;

namespace ICalendar.CalendarComponents
{
    public class VAlarm: CalendarComponent
    {
        public string Name => "VALARM";
    }
}
