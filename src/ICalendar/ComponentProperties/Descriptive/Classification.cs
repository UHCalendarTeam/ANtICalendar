using System.Collections.Generic;
using System.IO;
using ICalendar.ComponentProperties;
using ICalendar.GeneralInterfaces;
using ICalendar.Utils;

namespace ICalendar.ComponentProperties
{
    /// <summary>
    /// Purpose: This property defines the access classification for a
    ///calendar component.
    /// Conformance: The property can be specified once in a "VEVENT",
    ///"VTODO", or "VJOURNAL" calendar components.
    /// </summary>
    public class Classification:ISerialize, IComponentProperty, IValue<ClassificationValues.Values>
    {
      
        #region Properties
        public string Name => "CLASS";
        public IList<IPropertyParameter> PropertyParameters { get; set; }
        public ClassificationValues.Values Value { get; set; }
        #endregion

        public Classification()
        {
            Value = ClassificationValues.Values.PUBLIC;
        }

       
        public void Serialize(TextWriter writer)
        {
            
            writer.WriteLine(this.stringRepresentation());
        }

        public IComponentProperty Deserialize(string value)
        {
            value = value.ValuesSubString();
            Value = ClassificationValues.ConvertValue(value);
            return this;
        }

     
    }

    /// <summary>
    /// Define the possible values that a CLASSIFICATION property may have.
    /// Define some useful methods to convert from and to string the values.
    /// </summary>
    public class ClassificationValues
    {

        public ClassificationValues(string value)
        {
            Value = ConvertValue(value);
        }
        public enum Values
        {
            PUBLIC, PRIVATE, CONFIDENTIAL
        }

        public Values Value{ get; set; }

        /// <summary>
        /// Convert to string the value
        /// </summary>
        /// <returns></returns>
        public static string ToString(Values value)
        {
            switch (value)
            {
                case Values.CONFIDENTIAL:
                    return "CONFIDENTIAL";
                case Values.PRIVATE:
                    return "PRIVATE";
                case Values.PUBLIC:
                    return "PUBLIC";
                default:
                    return "PUBLIC";
            }
        }
        /// <summary>
        /// return a Value enum from the given string
        /// If the value is not recognised the return the 
        /// default PUBLC 
        /// </summary>
        /// <param name="str">The string representation of the Value</param>
        /// <returns>The equivalent of the string representation</returns>
        public static Values ConvertValue(string str)
        {
            switch (str)
            {
                case "CONFIDENTIAL":
                    return Values.CONFIDENTIAL;
                case "PRIVATE":
                    return Values.PRIVATE;
                case "PUBLC":
                    return Values.PUBLIC;
                default:
                    return Values.PUBLIC;    
            }
        }
    }
    
}
