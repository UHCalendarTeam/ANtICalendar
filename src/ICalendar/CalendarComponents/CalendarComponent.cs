using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            Properties = new List<IComponentProperty>();
        }

        public virtual void Serialize(TextWriter writer)
        {
            writer.WriteLine("BEGIN:" + Name);
            foreach (var property in Properties)
            {
                property.Serialize(writer);
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

        public IList<IComponentProperty> Properties { get; set; }
        public virtual string Name { get; }


        public virtual void AddItem(object component)
        {
            
            Properties.Add((IComponentProperty)component);
        }
    }
}
