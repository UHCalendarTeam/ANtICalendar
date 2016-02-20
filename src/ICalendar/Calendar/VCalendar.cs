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
    public class VCalendar : ISerialize
    {
        #region Constructors
        public VCalendar()
        {
            ComponentProperties = new List<IComponentProperty>();
            CalendarComponents = new List<ICalendarComponent>();
        }

        //temporal changes with parameters
        public VCalendar(/*string uriWriter*/ StreamWriter writer)
        {
            ComponentProperties = new List<IComponentProperty>();
            ComponentProperties.Add(new Prodid() { Value = ProId });
            ComponentProperties.Add(new Version() { Value = Version });
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
        public IList<IComponentProperty> ComponentProperties { get; set; }

        public IList<ICalendarComponent> CalendarComponents { get; set; }

        //REQUIRED PROPERTIES
        private static readonly string ProId = "//UHCalendarTeam//UHCalendar//EN";

        private static readonly string Version = "2.0";

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

        public void Serialize(TextWriter writer)
        {
            writer.WriteLine("BEGIN:VCALENDAR");
            foreach (var property in ComponentProperties)
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
