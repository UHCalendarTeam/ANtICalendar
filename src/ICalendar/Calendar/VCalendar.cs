using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ICalendar.CalendarComponents;
using ICalendar.CalendarProperties;
using ICalendar.GeneralInterfaces;
using Version = ICalendar.CalendarProperties.Version;

namespace ICalendar.Calendar
{
    public class VCalendar
    {
        public VCalendar(string methodVal, string calscaleVal)
        {
            CalendarComponents = new List<CalendarComponent>();

            CalScale = new CalScale() {Value = calscaleVal};
            Method = new Method() {Value = methodVal};
        }

        //At Least One
        public IList<CalendarComponent> CalendarComponents { get; set;}
       
        //REQUIRED PROPERTIES
        private static readonly ProdId ProId = new ProdId { Value = "//UHCalendarTeam//UHCalendar//EN" };

        private static readonly Version Version = new Version { Value = "2.0" };

        //OPTIONAL PROPERTIES
        public CalScale CalScale { get; set; }

        public Method Method { get; set; }

        //OPTIONAL MAY OCCUR MORE THAN ONCE
        //  X-PROP,  IANA-PROP

    }
}
