using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICalendar.ComponentProperties.Recurrence
{
    /// <summary>
    /// Calendar Components: VEVENT, VTODO, VJOURNAL -- STANDARD, DAYLIGHT subcomponents;
    /// Value Type: DATETIME/DATE;
    /// Properties Parameters: iana, non-standard, value data type, time zone identifier
    /// </summary>
    public class ExceptionDateTime : IComponentProperty<IEnumerable<System.DateTime>>
    {
        public string Name => "EXDATE";
        public IEnumerable<IPropertyParameter> PropertyParameters { get; set; }

        public void Serialize(TextWriter writer)
        {
            StringBuilder str = new StringBuilder("EXDATE:");
            var flag = false;
            foreach (var cat in Value)
            {
                if (flag)
                    str.Append(',');
                str.Append(cat);
                flag = true;
            }
            writer.WriteLine("{0}", str);
        }

        public IComponentProperty<IEnumerable<System.DateTime>> Deserialize(string value)
        {
            var valuesStartIndex = value.IndexOf(':') + 1;
            var strValues = value.Substring(valuesStartIndex);
            var values = strValues.Split(',', ':');
            List<System.DateTime> valuesConv = new List<System.DateTime>();
            foreach (var strval in values)
            {
                valuesConv.Add(System.DateTime.Parse(strval));
            }
            Value = valuesConv;
            return this;
        }

        public IEnumerable<System.DateTime> Value { get; set; }
    }
}
