using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICalendar.GeneralInterfaces;
using ICalendar.Utils;

namespace ICalendar.ComponentProperties
{
    /// <summary>
    /// Purpose: This property defines the equipment or resources
    ///anticipated for an activity specified by a calendar component.
    /// Conformance: This property can be specified once in "VEVENT" or
    ///"VTODO" calendar component.
    /// </summary>
    public class Resources: IComponentProperty, IValue<IList<string>>, ISerialize
    {
        #region Properties

        public string Name => "RESOURCES";
        public IList<IPropertyParameter> PropertyParameters { get; set; }
        public IList<string> Value { get;  set; }
        #endregion
        public void Serialize(TextWriter writer)
        {
            writer.WriteLine(this.stringRepresentation());
        }

        public IComponentProperty Deserialize(string value)
        {
            Value = value.ValuesList();
            return this;
        }
    }
}
