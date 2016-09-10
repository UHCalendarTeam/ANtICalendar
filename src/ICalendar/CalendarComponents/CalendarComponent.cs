using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ICalendar.GeneralInterfaces;

namespace ICalendar.CalendarComponents
{
    /// <summary>
    ///     The abstraction class for the different Calendar components implementations.
    /// </summary>
    public class CalendarComponent : ICalendarComponent
    {
        public CalendarComponent()
        {
            Properties = new Dictionary<string, IComponentProperty>();
            MultipleValuesProperties = new Dictionary<string, List<IComponentProperty>>();
        }

        [Obsolete]
        public virtual void Serialize(TextWriter writer)
        {
            writer.WriteLine("BEGIN:" + Name);

            foreach (var property in Properties.Values)
            {
                property.Serialize(writer);
            }
            if (this is ICalendarComponentsContainer)
            {
                var components = (this as ICalendarComponentsContainer).CalendarComponents;
                foreach (var comp in components)
                {
                    foreach (var component in comp.Value)
                    {
                        //TODO: check this out
                        if (component != null)
                            component.Serialize(writer);
                    }
                }
            }
            var alarmContainer = this as IAlarmContainer;
            if (alarmContainer != null)
            {
                foreach (var alarm in alarmContainer.Alarms)
                {
                    alarm.Serialize(writer);
                }
            }

            writer.WriteLine("END:" + Name);
        }

        /// <summary>
        ///     Add a CalendarComponent property to the object.
        /// </summary>
        /// <param name="component">The calendarProperty to be added.</param>
        public virtual void AddItem(ICalendarObject component)
        {
            var prop = component as IComponentProperty;
            if (prop == null)
                throw new ArgumentException("THe value should be an IComponentProperty");

            //TODO:this properties should implement other interface to indentify that may contains
            //multiples values, this way is gonna be simpler this verification, among other things

            //check if the property is already in the object. If it is then put it in the 
            //multiple property list.
            if (Properties.ContainsKey(prop.Name))
            {
                MultipleValuesProperties[prop.Name] = new List<IComponentProperty> { prop, Properties[prop.Name] };
                Properties.Remove(prop.Name);
            }
            else if (MultipleValuesProperties.ContainsKey(prop.Name))
                MultipleValuesProperties[prop.Name].Add(prop);
            else
                Properties.Add(prop.Name, prop);
        }

        /// <summary>
        ///     Returns the string representation of the
        /// </summary>
        /// <param name="properties"></param>
        /// <returns></returns>
        public string ToString(IEnumerable<string> properties)
        {
            var strBuilder = new StringBuilder();
            strBuilder.AppendLine("BEGIN:" + Name);

            ///take the requested properties 
            var singleReqProperties = Properties.Where(x => properties.Contains(x.Key)).Select(x => x.Value);
            foreach (var property in singleReqProperties)
                strBuilder.Append(property);

            ///take the  requested properties that are in the mutiple property list
            var multReqProperties =
                MultipleValuesProperties
                .Where(prop => properties.Contains(prop.Key))
                .SelectMany(prop => prop.Value);
            foreach (var componentProperty in multReqProperties)
            {
                strBuilder.Append(componentProperty);
            }

            //Check if the icalendarComponent contains other calendar components.
            var container = this as ICalendarComponentsContainer;
            if (container != null)
                foreach (var component in container.CalendarComponents)
                    foreach (var comp in component.Value)
                        if (comp != null)
                            strBuilder.Append(comp);

            strBuilder.AppendLine("END:" + Name);
            return strBuilder.ToString();
        }

        public Dictionary<string, List<IComponentProperty>> MultipleValuesProperties { get; set; }

        /// <summary>
        ///     Return the property by the given name.
        /// </summary>
        /// <param name="propName">Property name.</param>
        /// <returns>The property with the given name. </returns>
        public IComponentProperty GetComponentProperty(string propName)
        {
            return Properties.ContainsKey(propName) ? Properties[propName] : null;
        }

        /// <summary>
        ///     Returns the properties that might have multiple
        ///     definitions.(i.e RRULE, ATTENDEE)
        /// </summary>
        /// <param name="propName"></param>
        /// <returns></returns>
        public List<IComponentProperty> GetMultipleCompProperties(string propName)
        {
            return MultipleValuesProperties.ContainsKey(propName) ? MultipleValuesProperties[propName] : null;
        }

        public override string ToString()
        {
            var strBuilder = new StringBuilder();
            strBuilder.AppendLine("BEGIN:" + Name);

            var multipleProperties =
                MultipleValuesProperties.Values.SelectMany(multipleValuesProperty => multipleValuesProperty);

            var allProperties = multipleProperties.Concat(Properties.Values);

            foreach (var property in allProperties)
                strBuilder.Append(property);

            //if the object contains other calendarCOmponents
            var calendarComponentsContainer = this as ICalendarComponentsContainer;
            if (calendarComponentsContainer != null)
            {
                var calendarComponents = calendarComponentsContainer.CalendarComponents;
                foreach (var component in calendarComponents)
                    foreach (var comp in component.Value.Where(comp => comp != null))
                        strBuilder.Append(comp);
            }

            strBuilder.AppendLine("END:" + Name);
            return strBuilder.ToString();
        }

        /// <summary>
        ///     Get the VALARM objects if any.
        /// </summary>
        /// <returns></returns>
        public List<VAlarm> GetAlarms()
        {
            var calendarComponentsContainer = this as ICalendarComponentsContainer;
            var calendarComponents = calendarComponentsContainer?.CalendarComponents;
            return calendarComponents?
                .Where(calComp => calComp.Key == "VALARM")
                .SelectMany(alarm => alarm.Value)
                .Select(x=>x as VAlarm).ToList();
        }

        #region Properties

        public Dictionary<string, IComponentProperty> Properties { get; set; }
        public virtual string Name { get; set; }

        public IComponentProperty this[string name] => Properties.ContainsKey(name) ? Properties[name] : null;

        #endregion Properties
    }
}