using System.Collections.Generic;
using System.IO;
using ICalendar.GeneralInterfaces;
using static ICalendar.Utils.Utils;

namespace ICalendar.ComponentProperties
{
    public class Comment: IComponentProperty, IValue<string>
    {
        #region Properties

        public string Name => "COMMENT";
        public IList<IPropertyParameter> PropertyParameters { get; set; }
        public string Value { get; set; }

      

        #endregion

        public void Serialize(TextWriter writer)
        {
            writer.WriteLine(this.StringRepresentation());
        }

        public IComponentProperty Deserialize(string value)
        {
            Value = value.ValuesSubString();
            return this;
        }
      
    }
}
