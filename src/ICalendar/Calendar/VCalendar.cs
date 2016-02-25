using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICalendar.CalendarComponents;
using ICalendar.ComponentProperties;
using ICalendar.GeneralInterfaces;
using Version = ICalendar.ComponentProperties.Version;


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
            Properties = new Dictionary<string, IList<IComponentProperty>>();
            CalendarComponents = new Dictionary<string, IList<ICalendarComponent>>();
        }
        public VCalendar(Dictionary<string, IList<IComponentProperty>> properties, IDictionary<string, IList<ICalendarComponent>> calComponents)
        {
            Properties = properties;
            CalendarComponents = calComponents;
        }

        //temporal changes with parameters
        public VCalendar(/*string uriWriter*/ StreamWriter writer)
        {
            Properties = new Dictionary<string, IList<IComponentProperty>>();
            var proid = new Prodid() {Value = ProId};
            var version = new Version() {Value = Version};
            Properties.Add(proid.Name, new List<IComponentProperty>() {proid});
            Properties.Add(version.Name, new List<IComponentProperty>() {version});
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

        #region Properties
        
        
        public TextWriter writer { get; set; }

        public string Name => "VCALENDAR";
      

        //REQUIRED PROPERTIES
        private static readonly string ProId = "//UHCalendarTeam//UHCalendar//EN";

        private static readonly string Version = "2.0";

        //OPTIONAL PROPERTIES
        public Calscale CalScale { get; set; }

        public Method Method { get; set; }

        public IDictionary<string, IList<ICalendarComponent>> CalendarComponents { get; }

        public IDictionary<string, IList<IComponentProperty>> Properties { get; }

        //OPTIONAL MAY OCCUR MORE THAN ONCE
        //  X-PROP,  IANA-PROP
        #endregion

        public void AddItem(ICalendarObject calComponent)
        {
            var prop = calComponent as IComponentProperty; 
            if (prop != null)
            {
                if (Properties.ContainsKey(prop.Name))
                    Properties[prop.Name].Add(prop);
                else
                    Properties.Add(prop.Name, new List<IComponentProperty>(1) {prop});
                
                return;
            }
            
            if(CalendarComponents.ContainsKey(calComponent.Name))
                CalendarComponents[calComponent.Name].Add((ICalendarComponent)calComponent);
            else 
                CalendarComponents.Add(calComponent.Name,
                    new List<ICalendarComponent>(1) { (ICalendarComponent)calComponent});
        }

        public void Serialize(TextWriter writer)
        {
            writer.WriteLine("BEGIN:VCALENDAR");
            foreach (var properties in Properties)
            {
                foreach (var property in properties.Value)
                {
                     property.Serialize(writer);
                }
               
            }
            foreach (var components in CalendarComponents)
            {
                foreach (var component in components.Value)
                {
                     component.Serialize(writer);
                }
               
            }
            writer.WriteLine("END:VCALENDAR");
        }


        public override string ToString()
        {
            var a = new Stopwatch();
            var strBuilder = new StringBuilder();
            strBuilder.AppendLine("BEGIN:VCALENDAR");
            foreach (var property in Properties)
            {
                strBuilder.Append(property.ToString());
                
            }
            foreach (var component in CalendarComponents)
            {

                strBuilder.Append(component.ToString());
            }
            strBuilder.AppendLine("END:VCALENDAR");
            return strBuilder.ToString();

        }

        /// <summary>
        /// Return all the CalendarComponents given the name.
        /// </summary>
        /// <param name="compName">CalendarComponent name.</param>
        /// <returns>The components with the given name.</returns>
        public IList<ICalendarComponent> GetCalendarComponents(string compName)
        {
            return CalendarComponents.ContainsKey(compName) ? CalendarComponents[compName] : null;
        }

        /// <summary>
        /// Return all the properties by the given name.
        /// </summary>
        /// <param name="propName">Property name.</param>
        /// <returns>The properties with the given name. </returns>
        public IList<IComponentProperty> GetComponentProperties(string propName)
        {
            return Properties.ContainsKey(propName) ? Properties[propName] : null;
        } 



    }
}
