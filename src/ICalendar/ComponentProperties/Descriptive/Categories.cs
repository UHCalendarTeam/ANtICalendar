using System.Collections.Generic;
using ICalendar.ComponentProperties;
using ICalendar.GeneralInterfaces;
using static ICalendar.Utils.Utils;

namespace ICalendar.ComponentProperties
{
    /// <summary>
    /// ---Purpose: This property defines the categories for a calendar
    ///component.
    /// ---Conformance: The property can be specified within "VEVENT", "VTODO",
    ///or "VJOURNAL" calendar components.
    /// 
    /// 
    /// </summary>
    /// ////
    public class Categories:IComponentProperty, IValue<IList<string>>
    {
        #region Properties
        public string Name => "CATEGORIES";
        public IList<IPropertyParameter> PropertyParameters { get; set; }

        public IList<string> Value { get; set; }
        #endregion

        public void Serialize(System.IO.TextWriter writer)
        {

            
            writer.WriteLine(this.StringRepresentation());        
            
        }

        public IComponentProperty Deserialize(string value)
        {
            Value = value.ValuesList();
            return this;
        }


       
    }


 /*   public class ComponentProperty : ISerialize, IComponentProperty
    {
        public void Serialize(TextWriter writer)
        {
            writer.WriteLine(this.stringRepresentation());
        }

        public IComponentProperty Deserialize(string value)
        {
            throw new NotImplementedException();
        }

        public string Name { get; }
    }*/
}
