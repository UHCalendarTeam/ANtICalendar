using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICalendar.GeneralInterfaces;

namespace ICalendar.ComponentProperties
{
    /// <summary>
    /// Calendar Components: VTODO;
    /// Value Type: DATETIME/DATE;
    /// Properties Parameters: iana, non-standard, value data type, time zone identifier
    /// </summary>
    public class DateTimeDue : DateTimeProperty
    {
        public override string Name => "DUE";

        public override void Serialize(TextWriter writer)
        {
            StringBuilder str = new StringBuilder("DUE:");
            str.Append(Value);
            writer.WriteLine("{0}", str);
        }

        public override IComponentProperty Deserialize(string value)
        {
            var valueStartIndex = value.IndexOf(':') + 1;
            var strValue = System.DateTime.Parse(value.Substring(valueStartIndex));
            Value = strValue;
            return this;
        }

        public override System.DateTime Value { get; set; }
    }
}
