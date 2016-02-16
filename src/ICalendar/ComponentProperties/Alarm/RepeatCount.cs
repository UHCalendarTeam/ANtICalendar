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
    /// Value Type: INTEGER;
    /// Properties Parameters: iana, non-standard
    /// </summary>
    public class RepeatCount : IComponentProperty, IValue<int>
    {

        public string Name => "REPEAT";
        public IList<IPropertyParameter> PropertyParameters { get; set; }

        public void Serialize(TextWriter writer)
        {
            StringBuilder str = new StringBuilder("REPEAT:");
            str.Append(Value);
            writer.WriteLine("{0}", str);
        }

        public IComponentProperty Deserialize(string value)
        {
            var valueStartIndex = value.IndexOf(':') + 1;
            var strValue = int.Parse(value.Substring(valueStartIndex));
            Value = strValue;
            return this;
        }

        public int Value { get; set; }

    }
}
