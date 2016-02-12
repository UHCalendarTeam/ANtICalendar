using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICalendar.ComponentProperties.DateTime
{
    /// <summary>
    /// Calendar Components: VEVENT, VFREEBUSY;
    /// Value Type: UTC;
    /// Properties Parameters: iana, non-standard, value data type, time zone identifier
    /// </summary>
    public class DateTimeEnd : DateTimeProperty
    {
        public override string Name => "DTEND";
        public override void Serialize()
        {
            throw new NotImplementedException();
        }

        public override IComponentProperty Deserialize()
        {
            throw new NotImplementedException();
        }

        public override System.DateTime Value { get; }
    }
}
