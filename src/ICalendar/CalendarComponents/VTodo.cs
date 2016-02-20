using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ICalendar.ComponentProperties;
using ICalendar.GeneralInterfaces;

namespace ICalendar.CalendarComponents
{
    public class VTodo: CalendarComponent, IAlarmContainer
    {
        public VTodo()
        {
            Alarms = new List<VAlarm>();
        }

        public string Name => "VTODO";
        public IList<IComponentProperty> Properties { get; set; }

        public void Serialize(TextWriter writer)
        {
            throw new NotImplementedException();
        }

        public IComponentProperty Deserialize(string value)
        {
            throw new NotImplementedException();
        }

        public IList<VAlarm> Alarms { get; set; }
    }
}
