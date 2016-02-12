using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICalendar.ComponentProperties.DateTime
{
    /// <summary>
    /// Calendar Components: VFREEBUSY;
    /// Value Type: PERIOD;
    /// Properties Parameters: iana, non-standard, free/busy time type
    /// </summary>
    public class FreeBusyTime : IComponentProperty, ISerialize
    {
        public string Name => "FREEBUSY";
        public void Serialize()
        {
            throw new NotImplementedException();
        }

        public IComponentProperty Deserialize()
        {
            throw new NotImplementedException();
        }

        //change this to PERIOD type implement
        public int Value { get; }
    }
}
