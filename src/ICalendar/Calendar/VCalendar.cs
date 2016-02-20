using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ICalendar.CalendarProperties;
using ICalendar.GeneralInterfaces;
using Version = ICalendar.CalendarProperties.Version;

namespace ICalendar.Calendar
{
    public class VCalendar
    {
        public VCalendar(string methodVal, string calscaleVal)
        {
            ComponentProperties = new List<IComponentProperty>();

            CalScale = new CalScale() {Value = calscaleVal};
            Method = new Method() {Value = methodVal};
        }

        //At Least One
        public IList<IComponentProperty> ComponentProperties { get; set; }
       
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
