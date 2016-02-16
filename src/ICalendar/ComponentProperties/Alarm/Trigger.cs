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
    /// Calendar Components: VALARM;
    /// Value Type: DURATION/DATETIME;
    /// Properties Parameters: iana, non-standard, value data type, time zone identifier, trigger relationship
    /// </summary>
    public class Trigger : IComponentProperty, IValue<System.DateTime>
    {

        public string Name => "TRIGGER";
        public IList<IPropertyParameter> PropertyParameters { get; set; }

        public void Serialize(TextWriter writer)
        {
            StringBuilder str = new StringBuilder("TRIGGER:");
            str.Append(Value);
            writer.WriteLine("{0}", str);
        }

        public IComponentProperty Deserialize(string value)
        {
            var valueStartIndex = value.IndexOf(':') + 1;
            var strValue = System.DateTime.Parse(value.Substring(valueStartIndex));
            Value = strValue;
            return this;
        }

        public System.DateTime Value { get; set; }
    }
}
