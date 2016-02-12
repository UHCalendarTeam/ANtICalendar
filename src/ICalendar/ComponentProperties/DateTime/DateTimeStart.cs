using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICalendar.ComponentProperties.DateTime
{
    /// <summary>
    /// Calendar Components: VTODO, VEVENT, VFREBUSY -- STANDARD, DAYLIGHT subcomponents;
    /// Value Type: DATETIME/DATE;
    /// Properties Parameters: iana, non-standard, value data type, time zone identifier
    /// </summary>
    public class DateTimeStart : DateTimeProperty
    {
        public override string Name => "DTSTART";
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
