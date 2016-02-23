using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICalendar.CalendarComponents;
using ICalendar.ComponentProperties;
using ICalendar.GeneralInterfaces;



namespace ICalendar.Calendar
{
    /// <summary>
    /// Represent the main class of a calendar.
    /// COntains the component properties and calendar components of the calendar.
    /// </summary>
    public class VCalendar : ISerialize, ICalendarComponentsContainer, IComponentPropertiesContainer, IAggregator, ICalendarObject
    {
        #region Constructors
        public VCalendar()
        {
            Properties = new List<IComponentProperty>();
            CalendarComponents = new List<ICalendarComponent>();
        }
        public VCalendar(List<IComponentProperty> properties, List<ICalendarComponent> calComponents)
        {
            Properties = properties;
            CalendarComponents = calComponents;
        }

        //temporal changes with parameters
        public VCalendar(/*string uriWriter*/ StreamWriter writer)
        {
            Properties = new List<IComponentProperty>();
            Properties.Add(new Prodid() { Value = ProId });
            Properties.Add(new Version() { Value = Version });
            //Aignar uri a un filestream

            //Asigna directamente el writer
            this.writer = writer;
        }

        //public VCalendar(string methodVal, string calscaleVal)
        //{
        //    ComponentProperties = new List<IComponentProperty>();
        //    CalendarComponents = new List<ICalendarComponent>();

        //    CalScale = new Calscale() { Value = calscaleVal };
        //    Method = new Method() { Value = methodVal };
        //}
        #endregion


        public TextWriter writer { get; set; }

        //At Least One
        public IList<IComponentProperty> Properties { get; set; }

        public IList<ICalendarComponent> CalendarComponents { get; set; }

        //REQUIRED PROPERTIES
        private static readonly string ProId = "//UHCalendarTeam//UHCalendar//EN";

        private static readonly string Version = "2.0";

        //OPTIONAL PROPERTIES
        public Calscale CalScale { get; set; }

        public Method Method { get; set; }

        //OPTIONAL MAY OCCUR MORE THAN ONCE
        //  X-PROP,  IANA-PROP


        public void AddItem(ICalendarObject calComponent)
        {
            var comp = calComponent as IComponentProperty; 
            if (comp != null)
            {
                Properties.Add(comp);
                return;
            }
            CalendarComponents.Add((ICalendarComponent)calComponent);
        }

        public void Serialize(TextWriter writer)
        {
            writer.WriteLine("BEGIN:VCALENDAR");
            foreach (var property in Properties)
            {
                property.Serialize(writer);
            }
            foreach (var component in CalendarComponents)
            {
                component.Serialize(writer);
            }
            writer.WriteLine("END:VCALENDAR");
        }
    }
}
