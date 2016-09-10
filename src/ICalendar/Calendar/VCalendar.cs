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
    ///     Is the object representation of the iCalendar component file VCALENDAR.
    ///     Contains the component properties and calendar components of the VCALENDARs.
    /// </summary>
    public class VCalendar : ISerialize, ICalendarComponentsContainer, IComponentPropertiesContainer, IAggregator,
        ICalendarObject
    {
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
            Dictionary<string, IList<ICalendarComponent>> calComponents)
        {
            Properties = properties;
            CalendarComponents = calComponents;
        }

        /// <summary>
        ///     THis constructor is deprecated.
        ///     Use the Parse method instead.
        /// </summary>
        /// <param name="calendarString"></param>
        [Obsolete("Use the static method Parse instead. For the next version is gonna be removed.")]
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
                if (!Parser.LineParser(line, out name, out parameters, out value))
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

        #endregion Constructors

        #region Properties

        public string Name => "VCALENDAR";

        //REQUIRED PROPERTIES
        private static readonly string ProId = "//UHCalendarTeam//UHCalendar//EN";

        private static readonly string Version = "2.0";

        /*//OPTIONAL PROPERTIES
        public Calscale CalScale { get; set; }

        public Method Method { get; set; }*/

        public Dictionary<string, IList<ICalendarComponent>> CalendarComponents { get; }

        public Dictionary<string, IComponentProperty> Properties { get; }

        //OPTIONAL MAY OCCUR MORE THAN ONCE
        //  X-PROP,  IANA-PROP

        #endregion Properties

        #region Methods

        /// <summary>
        ///     Add an item to the VCALENDAR.
        ///     The item HAS TO BE either an ComponentProperty or CalendarComponent.
        /// </summary>
        /// <param name="calObject">The object to be added.</param>
        public void AddItem(ICalendarObject calObject)
        {
            var calendarProperty = calObject as IComponentProperty;

            //if the object is a property, add it to the properties container
            if (calendarProperty != null)
            {
                Properties.Add(calendarProperty.Name, calendarProperty);
                return;
            }

            //if is not a property add it to the calendar components container

            var calComponent = calObject as ICalendarComponent;

            if (CalendarComponents.ContainsKey(calComponent.Name))
                CalendarComponents[calComponent.Name].Add(calComponent);
            else
                CalendarComponents.Add(calComponent.Name,
                    new List<ICalendarComponent>(1) {calComponent});
        }

        /// <summary>
        ///     Writes in the TextWriter the string representation
        ///     of the calendar.
        /// </summary>
        /// <param name="writer"></param>
        [Obsolete("It's gonna be removed in the next version of the library.")]
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
        ///     Return all the CalendarComponents that match with the given the name.
        /// </summary>
        /// <param name="componentName">The name of the CalendarComponent.</param>
        /// <returns>
        ///     The components with the given name. Null if the VCalendar doesn't contain
        ///     a CalendarComponent with the given name.
        /// </returns>
        public IList<ICalendarComponent> GetCalendarComponents(string componentName)
        {
            return CalendarComponents.ContainsKey(componentName) ? CalendarComponents[componentName] : null;
        }

        /// <summary>
        ///     Return the VCALENDAR property with the given name.
        /// </summary>
        /// <param name="propName">The name of the desired property.</param>
        /// <returns>The property with the given name. </returns>
        public IComponentProperty GetComponentProperties(string propName)
        {
            return Properties.ContainsKey(propName) ? Properties[propName] : null;
        }

        /// <summary>
        ///     Returns the string representation of the
        ///     VCALENDAR object following the format
        ///     defined in the iCalendar protocol (RFC 5545).
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
        ///     Return the string representation of the VCALENDAR object
        ///     with just the given properties and components.
        /// </summary>
        /// <param name="calData">Properties and components to print.</param>
        /// <returns></returns>
        public string ToString(IXMLTreeStructure calData)
        {
            var strBuilder = new StringBuilder();

            strBuilder.AppendLine("BEGIN:VCALENDAR");

            ///take the first node in the tree that contains VCALENDAR in the 
            /// attr "name"
            var vCal = calData.Children.Where(x => x.NodeName == "comp").
                First(x => x.Attributes.ContainsValue("VCALENDAR"));

            ///take the name of the properties in VCALENDAR that have to be
            /// returned
            var propToReturn = vCal.Children
                .Where(x => x.NodeName == "prop")
                .SelectMany(x => x.Attributes.Values);

            ///take those properties from the VCalendar object
            foreach (var property in Properties.Values.Where(x => propToReturn.Contains(x.Name)))
            {
                strBuilder.Append(property);
            }

            ///take the desired calendar component names from the tree
            var compToReturn = vCal.Children.Where(x => x.NodeName == "comp").
                SelectMany(x => x.Attributes.Values);

            ///take the calendar components from the VCALENDAR object
            foreach (var component in CalendarComponents.Where(comp => compToReturn.Contains(comp.Key)))
            {
                ///take the properties of the current component that are in the
                /// node of the tree with name = to the current component.
                var properties = vCal.Children.Where(x => x.NodeName == "comp")
                    .First(x => x.Attributes.ContainsValue(component.Key))
                    .Children.SelectMany(x => x.Attributes.Values);

                ///take the string representation of the current cal component
                /// and all the requested properties
                strBuilder.Append(component.Value.First().ToString(properties));
            }
            strBuilder.AppendLine("END:VCALENDAR");
            return strBuilder.ToString();
        }

        /// <summary>
        ///     Parse the text that contains the iCalendar representation.
        ///     Create an instance of VCALENDAR object with all the calendar components
        ///     and properties.
        /// </summary>
        /// <param name="calendarString">The calendar representation to be parsed.</param>
        /// <returns>The VCaledar instance.</returns>
        public static VCalendar Parse(string calendarString)
        {
            return Parser.iCalendarParser(calendarString);
        }

        #endregion
    }
}