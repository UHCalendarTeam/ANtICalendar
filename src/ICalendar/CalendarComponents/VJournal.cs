using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ICalendar.ComponentProperties;
using ICalendar.GeneralInterfaces;

namespace ICalendar.CalendarComponents
{
    public class VJournal:CalendarComponent
    {
        public string Name => "VJOURNAL";
      

        public void Serialize(TextWriter writer)
        {
            throw new NotImplementedException();
        }

        public IComponentProperty Deserialize(string value)
        {
            throw new NotImplementedException();
        }
    }
}
