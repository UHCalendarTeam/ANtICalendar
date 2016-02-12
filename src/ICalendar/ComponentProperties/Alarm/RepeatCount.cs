using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICalendar.ComponentProperties.Alarm
{
    /// <summary>
    /// Calendar Components: VALARM;
    /// Value Type: INTEGER;
    /// Properties Parameters: iana, non-standard
    /// </summary>
    public class RepeatCount : IComponentProperty, ISerialize
    {

        public string Name => "REPEAT";
        public void Serialize()
        {
            throw new NotImplementedException();
        }

        public IComponentProperty Deserialize()
        {
            throw new NotImplementedException();
        }

        public int Value { get; }
    }
}
