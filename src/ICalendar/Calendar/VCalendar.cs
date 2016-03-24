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
using ICalendar.Factory;
using ICalendar.GeneralInterfaces;
using ICalendar.PropertyParameters;
using Version = ICalendar.ComponentProperties.Version;
using ICalendar.Utils;
using TreeForXml;


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
            Properties = new Dictionary<string, IComponentProperty>();
            CalendarComponents = new Dictionary<string, IList<ICalendarComponent>>();
        }
        public VCalendar(Dictionary<string, IComponentProperty> properties, IDictionary<string, IList<ICalendarComponent>> calComponents)
        {
            Properties = properties;
            CalendarComponents = calComponents;
        }

        //temporal changes with parameters
        public VCalendar(/*string uriWriter*/ StreamWriter writer)
        {
            Properties = new Dictionary<string, IComponentProperty>();
            var proid = new Prodid() {Value = ProId};
            var version = new Version() {Value = Version};
            Properties.Add(proid.Name, proid);
            Properties.Add(version.Name, version);
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


        public VCalendar(string calendarString)
        {
            var calCompFactory = new CalendarComponentFactory();
            var compPropFactory = new ComponentPropertyFactory();
            var assemblyNameCalendar = "ICalendar.Calendar.";
            string name = "";
            string value = "";
            List<PropertyParameter> parameters = new List<PropertyParameter>();
            ICalendarObject calComponent = null;
            ICalendarObject compProperty = null;
            Stack<ICalendarObject> objStack = new Stack<ICalendarObject>();
            Type type = null;
            var lines = Parser.CalendarReader(calendarString);
            foreach (var line in lines)
            {
                if (!Parser.CalendarParser(line, out name, out parameters, out value))
                    continue;
                //TODO: Do the necessary with the objects that dont belong to CompProperties
                if (name == "BEGIN")
                {
                    var className = value;
                    className = className.Substring(0, 2) + className.Substring(2).ToLower();
                    if (value == "VCALENDAR")
                    {
                        type = Type.GetType(assemblyNameCalendar + className);
                        calComponent = Activator.CreateInstance(type) as ICalendarObject;
                    }
                    else
                        calComponent = calCompFactory.CreateIntance(className);
                    objStack.Push(calComponent);
                    continue;
                }
                if (name == "END")
                {
                    var endedObject = objStack.Pop();
                    //if the last object in the stack is an VCalendar then
                    //is the end of the parsing
                    if (endedObject is VCalendar)
                    {
                        var calendar = endedObject as VCalendar;
                        Properties = calendar.Properties;
                        CalendarComponents = calendar.CalendarComponents;
                        return;
                    }
                    ((IAggregator)objStack.Peek()).AddItem(endedObject);
                    continue;
                }
                string propSysName = name;
                if (name.Contains("-"))
                    propSysName = name.Replace("-", "_");
                propSysName = propSysName.Substring(0, 1) + propSysName.Substring(1).ToLower();
                compProperty = compPropFactory.CreateIntance(propSysName, name);
                if (compProperty == null)
                    continue;
                //if come an iana property that we dont recognize
                //so dont do anything with it
                //try
                //{
                //    compProperty = Activator.CreateInstance(type);
                //}
                //catch (System.Exception)
                //{
                //    continue;
                //}

                var topObj = objStack.Peek();
                ((IAggregator)topObj).AddItem(((IDeserialize)compProperty).Deserialize(value, parameters));


            }
           
            throw new ArgumentException("The calendar file MUST contain at least an element.");
        }
        #endregion

        #region Properties
        
        
        public TextWriter writer { get; set; }

        public string Name => "VCALENDAR";
      

        //REQUIRED PROPERTIES
        private static readonly string ProId = "//UHCalendarTeam//UHCalendar//EN";

        private static readonly string Version = "2.0";

        /*//OPTIONAL PROPERTIES
        public Calscale CalScale { get; set; }

        public Method Method { get; set; }*/

        public IDictionary<string, IList<ICalendarComponent>> CalendarComponents { get; }

        public IDictionary<string, IComponentProperty> Properties { get; }
       

        //OPTIONAL MAY OCCUR MORE THAN ONCE
        //  X-PROP,  IANA-PROP
        #endregion

        public void AddItem(ICalendarObject calComponent)
        {
            var prop = calComponent as IComponentProperty; 
            if (prop != null)
            {
              Properties.Add(prop.Name, prop);
                
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
            foreach (var property in Properties.Values)
            {
                property.Serialize(writer);
                
               
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


       

        /// <summary>
        /// Return all the CalendarComponents that match with given the name.
        /// </summary>
        /// <param name="compName">CalendarComponent name.</param>
        /// <returns>The components with the given name.</returns>
        public IList<ICalendarComponent> GetCalendarComponents(string compName)
        {
            return CalendarComponents.ContainsKey(compName) ? CalendarComponents[compName] : null;
        }

        /// <summary>
        /// Return  the properties by the given name.
        /// </summary>
        /// <param name="propName">Property name.</param>
        /// <returns>The properties with the given name. </returns>
        public IComponentProperty GetComponentProperties(string propName)
        {
            return Properties.ContainsKey(propName) ? Properties[propName] : null;
        }



        public override string ToString()
        {
            var strBuilder = new StringBuilder();

            strBuilder.AppendLine("BEGIN:VCALENDAR");
            foreach (var property in Properties.Values)
            {
                strBuilder.Append(property.ToString());
            }
            foreach (var components in CalendarComponents)
            {
                foreach (var component in components.Value)
                {
                    strBuilder.Append(component.ToString());
                }

            }
            strBuilder.AppendLine("END:VCALENDAR");
            return strBuilder.ToString();

        }

        /// <summary>
        /// Return the string representation of the calendar
        /// with just the given properties and components.
        /// </summary>
        /// <param name="calData">Properties and components to print.</param>
        /// <returns></returns>
        public string ToString(IXMLTreeStructure calData)
        {
            var strBuilder = new StringBuilder();

            strBuilder.AppendLine("BEGIN:VCALENDAR");
            var vCal = calData.Children.Where(x => x.NodeName == "comp").
                First(x => x.Attributes.ContainsValue("VCALENDAR"));
            IEnumerable<string> propToReturn = vCal.Children
                .Where(x => x.NodeName == "prop")
                .SelectMany(x => x.Attributes.Values);
            foreach (var property in Properties.Values.Where(x=>propToReturn.Contains(x.Name)))
            {
                strBuilder.Append(property.ToString());
            }
            IEnumerable<string> compToReturn = vCal.Children.Where(x => x.NodeName == "comp").
                SelectMany(x=>x.Attributes.Values);
            foreach (var component in CalendarComponents.Where(comp=>compToReturn.Contains(comp.Key)))
            {
                var properties = vCal.Children.Where(x => x.NodeName == "comp").First(x=>x.Attributes.ContainsValue(component.Key))
                    .Children.SelectMany(x => x.Attributes.Values);
                strBuilder.Append(component.Value.First().
                    ToString(properties));
            }
            strBuilder.AppendLine("END:VCALENDAR");
            return strBuilder.ToString();
        }
    }
}
