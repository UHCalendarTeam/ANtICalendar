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
    /// Purpose: This property defines the relative priority for a calendar
    ///component.
    /// Conformance: This property can be specified in "VEVENT" and "VTODO"
   /// calendar components.
    /// </summary>
    public class Priority:IComponentProperty, IValue<int>
    {
        #region Properties

        public string Name => "PRIORITY";
        public IList<IPropertyParameter> PropertyParameters { get; set; }
        public int Value { get; set; }
        #endregion

        public void Serialize(TextWriter writer)
        {
            writer.WriteLine(this.StringRepresentation());
        }

        public IComponentProperty Deserialize(string value)
        {
            try
            {
                Value = int.Parse(value.ValuesSubString().RemoveSpaces());
            }
            catch (ArgumentException e)
            {
                
                throw e;
            }
            return this;

        }

       
    }
}
