using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICalendar.ComponentProperties;
using ICalendar.GeneralInterfaces;

namespace ICalendar.CalendarComponents
{
    public class Event: ICalendarComponent
    {
        public string Name => "VEVENT";
        public IList<IComponentProperty> Properties { get; set; }
        
        public void Serialize(TextWriter writer)
        {
            StringBuilder str = new StringBuilder("BEGIN : VEVENT");
            //str.Append(Value);
            str.Append("END : VEVENT");
            writer.WriteLine("{0}", str);
        }

        public IComponentProperty Deserialize(string value)
        {
            throw new NotImplementedException();
        }
    }
}
