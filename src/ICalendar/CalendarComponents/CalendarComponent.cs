using ICalendar.GeneralInterfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

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
            MultipleValuesProperties = new Dictionary<string, List<IComponentProperty>>()
            {
                {"RRULE", new List<IComponentProperty>() },
                {"ATTENDEE", new List<IComponentProperty>() }
            };
        }

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
        ///
        /// </summary>
        /// <param name="component"></param>
        public virtual void AddItem(ICalendarObject component)
        {
            var prop = component as IComponentProperty;
            if (prop == null)
                throw new ArgumentException("THe value should be an IComponentProperty");
            if (prop.Name == "RRULE" || prop.Name == "ATTENDEE")
            {
                MultipleValuesProperties[prop.Name].Add(prop);
            }
            else
                Properties.Add(prop.Name, prop);
        }

        /// <summary>
        /// Returns the string representation of the
        /// </summary>
        /// <param name="properties"></param>
        /// <returns></returns>
        public string ToString(IEnumerable<string> properties)
        {
            var strBuilder = new StringBuilder();
            strBuilder.AppendLine("BEGIN:" + Name);

            foreach (var property in Properties.Where(x => properties.Contains(x.Key)).Select(x => x.Value))
                strBuilder.Append(property);

            if (properties.Contains("RRULE"))
                foreach (var rRule in MultipleValuesProperties["RRULE"])
                {
                    strBuilder.Append(rRule);
                }
            if (properties.Contains("ATTENDEE"))
                foreach (var attendee in MultipleValuesProperties["ATTENDEE"])
                {
                    strBuilder.Append(attendee);
                }

            //TODO: check this out
            var container = this as ICalendarComponentsContainer;
            if (container != null)
            {
                var components = container.CalendarComponents;
                foreach (var component in components)
                {
                    //TODO: check this out
                    foreach (var comp in component.Value)
                    {
                        if (comp != null)
                            strBuilder.Append(comp);
                    }
                }
            }
            //TODO: check this out
            var alarmContainer = this as IAlarmContainer;
            if (alarmContainer != null)
            {
                foreach (var alarm in alarmContainer.Alarms)
                {
                    strBuilder.Append(alarm);
                }
            }

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
        /// Returns the properties that might have multiple
        /// definitions.(i.e RRULE, ATTENDEE)
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

            foreach (var property in Properties.Values)
                strBuilder.Append(property);
            foreach (var prop in MultipleValuesProperties.Values.SelectMany(multipleValuesProperty => multipleValuesProperty))
                strBuilder.Append(prop);

            if (this is ICalendarComponentsContainer)
            {
                var components = (this as ICalendarComponentsContainer).CalendarComponents;
                foreach (var component in components)
                {
                    //TODO: check this out
                    foreach (var comp in component.Value)
                    {
                        if (comp != null)
                            strBuilder.Append(comp);
                    }
                }
            }
            var alarmContainer = this as IAlarmContainer;
            if (alarmContainer != null)
            {
                foreach (var alarm in alarmContainer.Alarms)
                {
                    strBuilder.Append(alarm);
                }
            }

            strBuilder.AppendLine("END:" + Name);
            return strBuilder.ToString();
        }

        public List<VAlarm> GetAlarms()
        {
            var alarmContainer = this as IAlarmContainer;
            return alarmContainer?.Alarms;
        }

        #region Properties

        public IDictionary<string, IComponentProperty> Properties { get; set; }
        public virtual string Name { get; set; }

        public IComponentProperty this[string name] => Properties.ContainsKey(name) ? Properties[name] : null;

        #endregion Properties
    }
}