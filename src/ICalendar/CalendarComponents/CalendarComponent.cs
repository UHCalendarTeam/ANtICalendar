using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICalendar.GeneralInterfaces;

namespace ICalendar.CalendarComponents
{
    /// <summary>
    /// The abstraction class for the different Calendar components implementations.
    /// </summary>
    public class CalendarComponent:ICalendarComponent
    {
        public CalendarComponent()
        {
            Properties = new Dictionary<string,IComponentProperty>();
            RRules = new List<IComponentProperty>();
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

        public IDictionary<string, IComponentProperty> Properties { get;  }
        public virtual string Name { get; }

        public List<IComponentProperty> RRules { get; } 

        public IComponentProperty this[string name] => Properties.ContainsKey(name) ? Properties[name] : null;


        public virtual void AddItem(ICalendarObject component)
        {
            var prop = component as IComponentProperty;
            if(prop.Name=="RRULE")
                RRules.Add(prop);
            else
                 Properties.Add(prop.Name, prop);
        }


        public override string ToString()
        {
            var strBuilder = new StringBuilder();
            strBuilder.AppendLine("BEGIN:" + Name);

            foreach (var property in Properties.Values)
                strBuilder.Append(property);
            foreach (var rRule in RRules)
            {
                strBuilder.Append(rRule);
            }
                
               
           
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


        /// <summary>
        /// Return all the properties by the given name.
        /// </summary>
        /// <param name="propName">Property name.</param>
        /// <returns>The properties with the given name. </returns>
        public IComponentProperty GetComponentProperty(string propName)
        {
            return Properties.ContainsKey(propName) ? Properties[propName] : null;
        }
    }
}
