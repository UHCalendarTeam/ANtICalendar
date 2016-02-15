using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ICalendar.ComponentProperties.DateTime
{
    /// <summary>
    /// Calendar Components: VTODO;
    /// Value Type: UTC;
    /// Properties Parameters: iana, non-standard
    /// </summary>
    public class DateTimeCompleted : DateTimeProperty
    {

        public override string Name => "COMPLETED";

        public override void Serialize(TextWriter writer)
        {
            StringBuilder str = new StringBuilder("COMPLETED:");
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
