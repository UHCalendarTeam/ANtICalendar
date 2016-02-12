using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICalendar.ComponentProperties.Recurrence
{
    /// <summary>
    /// Calendar Components: VFREEBUSY;
    /// Value Type: DATETIME/DATE/PERIOD;
    /// Properties Parameters: iana, non-standard, value data type, time zone identifier
    /// </summary>
    public class RecurrenceDateTime : IComponentProperty, ISerialize
    {
        public string Name => "RDATE";
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
