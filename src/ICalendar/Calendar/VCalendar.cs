using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using ICalendar.CalendarComponents;
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
            CalScale = new Calscale() {Value = calscaleVal};
            Method = new Method() {Value = methodVal};
        }

        //At Least One
        public IList<ICalendarComponent> CalendarComponents { get; set;}
        public IList<IComponentProperty> ComponentProperties { get; set; } 
       
       
        //REQUIRED PROPERTIES
        private static readonly string ProId =  "//UHCalendarTeam//UHCalendar//EN" ;

        private static readonly string Version =  "2.0" ;

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
