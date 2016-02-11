using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICalendar.ComponentProperties.Recurrence
{
    public class ExceptionDateTime:IComponentProperty, ISerialize
    {
        /*

        Calendar Components: VEVENT, VTODO, VJOURNAL -- STANDARD, DAYLIGHT subcomponents

        Value Type: DATETIME/DATE

        Properties Parameters: iana, non-standard, value data type, time zone identifier

        */

        public string Name => "EXDATE";
        public void Serialize()
        {
            throw new NotImplementedException();
        }

        public IComponentProperty Deserialize()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<System.DateTime> Value { get; }
    }
}
