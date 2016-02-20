using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using ICalendar.ComponentProperties;
using ICalendar.GeneralInterfaces;



namespace ICalendar.Calendar
{
    public class VCalendar
    {
        public VCalendar()
        {
            ComponentProperties = new List<IComponentProperty>();
            CalendarComponents = new List<ICalendarComponent>();
        }
        public VCalendar(string methodVal, string calscaleVal)
        {
            ComponentProperties = new List<IComponentProperty>();
            CalendarComponents = new List<ICalendarComponent>();

            CalScale = new Calscale() {Value = calscaleVal};
            Method = new Method() {Value = methodVal};
        }

        //At Least One
        public IList<IComponentProperty> ComponentProperties { get; set; }

        public IList<ICalendarComponent> CalendarComponents { get; set; } 
       
        //REQUIRED PROPERTIES
        private static readonly Prodid ProId = new Prodid { Value = "//UHCalendarTeam//UHCalendar//EN" };

        private static readonly Version Version = new Version { Value = "2.0" };

        //OPTIONAL PROPERTIES
        public Calscale CalScale { get; set; }

        public Method Method { get; set; }

        //OPTIONAL MAY OCCUR MORE THAN ONCE
        //  X-PROP,  IANA-PROP



        public void AddItem(object calComponent)
        {
            if (calComponent is IComponentProperty)
            {
                ComponentProperties.Add((IComponentProperty)calComponent);
                return;
            }
            CalendarComponents.Add((ICalendarComponent)calComponent);
        }
    }
}
