using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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

        public override void Serialize(TextWriter writer)
        {
            StringBuilder str = new StringBuilder("DTEND:");
            str.Append(Value);
            writer.WriteLine("{0}", str);
        }

        public override IComponentProperty<System.DateTime> Deserialize(string value)
        {
            var valueStartIndex = value.IndexOf(':') + 1;
            var strValue = System.DateTime.Parse(value.Substring(valueStartIndex));
            Value = strValue;
            return this;
        }

        public override System.DateTime Value { get; set; }
    }
}
