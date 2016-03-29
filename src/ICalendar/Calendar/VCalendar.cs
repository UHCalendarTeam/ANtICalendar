using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ICalendar.Factory;
using ICalendar.GeneralInterfaces;
using ICalendar.PropertyParameters;
using ICalendar.Utils;
using TreeForXml;

namespace ICalendar.Calendar
{
    /// <summary>
    ///     Is the object representation of the
    ///     iCalendar component VCALENDAR.
    ///     Contains the component properties and calendar components
    ///     of the VCALENDAR.
    /// </summary>
    public class VCalendar : ISerialize, ICalendarComponentsContainer, IComponentPropertiesContainer, IAggregator,
        ICalendarObject
    {
        /// <summary>
        ///     Add an item to the VCALENDAR.
        ///     The item SHOULD BE either an iCalendar property
        ///     or ICalendar component.
        /// </summary>
        /// <param name="calComponent"></param>
        public void AddItem(ICalendarObject calComponent)
        {
            var prop = calComponent as IComponentProperty;
            if (prop != null)
            {
                Properties.Add(prop.Name, prop);

                return;
            }

            if (CalendarComponents.ContainsKey(calComponent.Name))
                CalendarComponents[calComponent.Name].Add((ICalendarComponent) calComponent);
            else
                CalendarComponents.Add(calComponent.Name,
                    new List<ICalendarComponent>(1) {(ICalendarComponent) calComponent});
        }

        /// <summary>
        ///     Writes in the TextWriter the string representation
        ///     of the calendar.
        /// </summary>
        /// <param name="writer"></param>
        public void Serialize(TextWriter writer)
        {
            writer.WriteLine("BEGIN:VCALENDAR");
            foreach (var property in Properties.Values)
            {
                property.Serialize(writer);
            }
            foreach (var component in CalendarComponents.SelectMany(components => components.Value))
            {
                component.Serialize(writer);
            }
            writer.WriteLine("END:VCALENDAR");
        }


        /// <summary>
        ///     Return all the CalendarComponents that match with given the name.
        /// </summary>
        /// <param name="compName">CalendarComponent name.</param>
        /// <returns>The components with the given name.</returns>
        public IList<ICalendarComponent> GetCalendarComponents(string compName)
        {
            return CalendarComponents.ContainsKey(compName) ? CalendarComponents[compName] : null;
        }

        /// <summary>
        ///     Return a property by the given name.
        /// </summary>
        /// <param name="propName">Property name.</param>
        /// <returns>The property with the given name. </returns>
        public IComponentProperty GetComponentProperties(string propName)
        {
            return Properties.ContainsKey(propName) ? Properties[propName] : null;
        }

        /// <summary>
        ///     Returns the string representation of the
        ///     VCALENDAR object followinb the format
        ///     defined in iCalendar protocol (RFC 5545).
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var strBuilder = new StringBuilder();

            strBuilder.AppendLine("BEGIN:VCALENDAR");
            foreach (var property in Properties.Values)
            {
                strBuilder.Append(property);
            }
            foreach (var components in CalendarComponents)
            {
                foreach (var component in components.Value)
                {
                    strBuilder.Append(component);
                }
            }
            strBuilder.AppendLine("END:VCALENDAR");
            return strBuilder.ToString();
        }


        /// <summary>
        ///     Return the string representation of the calendar
        ///     with just the given properties and components.
        /// </summary>
        /// <param name="calData">Properties and components to print.</param>
        /// <returns></returns>
        public string ToString(IXMLTreeStructure calData)
        {
            var strBuilder = new StringBuilder();

            strBuilder.AppendLine("BEGIN:VCALENDAR");
            var vCal = calData.Children.Where(x => x.NodeName == "comp").
                First(x => x.Attributes.ContainsValue("VCALENDAR"));
            var propToReturn = vCal.Children
                .Where(x => x.NodeName == "prop")
                .SelectMany(x => x.Attributes.Values);
            foreach (var property in Properties.Values.Where(x => propToReturn.Contains(x.Name)))
            {
                strBuilder.Append(property);
            }
            var compToReturn = vCal.Children.Where(x => x.NodeName == "comp").
                SelectMany(x => x.Attributes.Values);
            foreach (var component in CalendarComponents.Where(comp => compToReturn.Contains(comp.Key)))
            {
                var properties = vCal.Children.Where(x => x.NodeName == "comp")
                    .First(x => x.Attributes.ContainsValue(component.Key))
                    .Children.SelectMany(x => x.Attributes.Values);
                strBuilder.Append(component.Value.First().
                    ToString(properties));
            }
            strBuilder.AppendLine("END:VCALENDAR");
            return strBuilder.ToString();
        }

        /// <summary>
        /// Parse the string that contain a calendar defines
        /// under the protocol RFC 5545. Builds an instance 
        /// of VCalendar with its components, properties..
        /// </summary>
        /// <param name="calendarString">The calendar to parse.</param>
        /// <returns>An instance of VCalendar.</returns>
        public static VCalendar Parse(string calendarString)
        {
            var calCompFactory = new CalendarComponentFactory();
            var compPropFactory = new ComponentPropertyFactory();
            var name = "";
            var value = "";
            var parameters = new List<PropertyParameter>();
            ICalendarObject calComponent = null;
            ICalendarObject compProperty = null;
            var objStack = new Stack<ICalendarObject>();
            Type type = null;
            var lines = Parser.CalendarReader(calendarString);

            foreach (var line in lines)
            {
                if (!Parser.CalendarParser(line, out name, out parameters, out value))
                    continue;
                switch (name)
                {
                    case "BEGIN":
                        var className = value;
                        className = className.Substring(0, 2) + className.Substring(2).ToLower();

                        ///if the component is vcalendar then create is
                        /// if not then call the factory to get the object
                        /// that name.
                        calComponent = value == "VCALENDAR" ? new VCalendar() : calCompFactory.CreateIntance(className);
                        objStack.Push(calComponent);
                        continue;
                    case "END":
                        var endedObject = objStack.Pop();
                        //if the last object in the stack is an VCalendar then
                        //is the end of the parsing
                        var vCalendar = endedObject as VCalendar;
                        if (vCalendar != null)
                            return vCalendar;

                        ///if the object is not a VCalendar means
                        /// that should be added to his father that
                        /// is the first in the stack
                        ((IAggregator) objStack.Peek()).AddItem(endedObject);
                        continue;
                }
                ///creates an instance of a property
                compProperty = compPropFactory.CreateIntance(name, name);

                var topObj = objStack.Peek();
                ((IAggregator) topObj).AddItem(((IDeserialize) compProperty).Deserialize(value, parameters));
            }

            throw new ArgumentException("The calendar file MUST contain at least an element.");
        }

        #region Constructors

        /// <summary>
        ///     Use this when the components and the
        ///     properties of the calendar are gonna be
        ///     set manually.
        /// </summary>
        public VCalendar()
        {
            Properties = new Dictionary<string, IComponentProperty>();
            CalendarComponents = new Dictionary<string, IList<ICalendarComponent>>();
        }

        public VCalendar(Dictionary<string, IComponentProperty> properties,
            IDictionary<string, IList<ICalendarComponent>> calComponents)
        {
            Properties = properties;
            CalendarComponents = calComponents;
        }

        /// <summary>
        /// THis constructor is deprecated.
        /// Use the Parse method instead.
        /// </summary>
        /// <param name="calendarString"></param>
        public VCalendar(string calendarString)
        {
            var calCompFactory = new CalendarComponentFactory();
            var compPropFactory = new ComponentPropertyFactory();
            var assemblyNameCalendar = "ICalendar.Calendar.";
            var name = "";
            var value = "";
            var parameters = new List<PropertyParameter>();
            ICalendarObject calComponent = null;
            ICalendarObject compProperty = null;
            var objStack = new Stack<ICalendarObject>();
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
                    ((IAggregator) objStack.Peek()).AddItem(endedObject);
                    continue;
                }
                var propSysName = name;
                if (name.Contains("-"))
                    propSysName = name.Replace("-", "_");
                propSysName = propSysName.Substring(0, 1) + propSysName.Substring(1).ToLower();
                compProperty = compPropFactory.CreateIntance(propSysName, name);
                if (compProperty == null)
                    continue;


                var topObj = objStack.Peek();
                ((IAggregator) topObj).AddItem(((IDeserialize) compProperty).Deserialize(value, parameters));
            }

            throw new ArgumentException("The calendar file MUST contain at least an element.");
        }

        #endregion

        #region Properties

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
    }
}