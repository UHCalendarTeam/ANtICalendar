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
    /// Purpose: This property defines the persistent, globally unique
    ///identifier for the calendar component.
    /// Conformance: The property MUST be specified in the "VEVENT",
    ///"VTODO", "VJOURNAL", or "VFREEBUSY" calendar components.
    /// </summary>
    public class UniqueIdentifier: IComponentProperty, IValue<string>
    {
        public string Name => "UID";
        public IList<IPropertyParameter> PropertyParameters { get; set; }
        public string Value { get; set; }
        public void Serialize(TextWriter writer)
        {
            writer.WriteLine(this.StringRepresentation());
        }

        public IComponentProperty Deserialize(string value)
        {
            Value = value.ValuesSubString();
            return this;
        }

        public void Generate()
        {
            var str = new StringBuilder(DateTime.Now.ToString("yyyyMMddhhmmss")).
                Append(DateTime.Now.Millisecond).Append('@');
            
            //TODO: Add the right side( the domain of the current computer)
            Value = str.ToString();
        }
    }
}
