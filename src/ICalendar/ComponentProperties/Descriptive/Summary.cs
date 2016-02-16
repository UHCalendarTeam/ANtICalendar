using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICalendar.GeneralInterfaces;
using static ICalendar.Utils.Utils;

namespace ICalendar.ComponentProperties
{
    /// <summary>
    /// Purpose: This property defines a short summary or subject for the
    ///calendar component.
    /// Conformance: The property can be specified in "VEVENT", "VTODO",
    ///"VJOURNAL", or "VALARM" calendar components.
    /// </summary>
    public class Summary:IComponentProperty, IValue<String>, ISerialize
    {
        public string Name => "SUMMARY";
        public IList<IPropertyParameter> PropertyParameters { get; set; }
        public string Value { get;  set; }
        public void Serialize(TextWriter writer)
        {
            writer.WriteLine(this.stringRepresentation());
        }

        public IComponentProperty Deserialize(string value)
        {
            Value = value.ValuesSubString();
            return this;
        }
    }
}
