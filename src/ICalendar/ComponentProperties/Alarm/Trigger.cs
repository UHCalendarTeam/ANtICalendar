using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICalendar.ComponentProperties.Alarm
{
    /// <summary>
    /// Calendar Components: VALARM;
    /// Value Type: DURATION/DATETIME;
    /// Properties Parameters: iana, non-standard, value data type, time zone identifier, trigger relationship
    /// </summary>
    public class Trigger : IComponentProperty, ISerialize
    {

        public string Name => "TRIGGER";
        public void Serialize()
        {
            throw new NotImplementedException();
        }

        public IComponentProperty Deserialize()
        {
            throw new NotImplementedException();
        }

        public System.DateTime Value { get; }
    }
}
