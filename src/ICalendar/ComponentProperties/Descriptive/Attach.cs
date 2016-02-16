using System;
using System.Collections.Generic;
using System.IO;
using ICalendar.ComponentProperties;
using ICalendar.GeneralInterfaces;

namespace ICalendar.ComponentProperties
{
    /// <summary>
    /// --Purpose: This property provides the capability to associate a
    //document object with a calendar component
    ///--Conformance: This property can be specified multiple times in a
    ///"VEVENT", "VTODO", "VJOURNAL", or "VALARM" calendar component with
    ///the exception of AUDIO alarm that only allows this property to
    ///occur once.
    /// </summary>
    public class Attach : IComponentProperty, ISerialize
    {
        #region Properties
        public string Name => "ATTACH";
        public IList<IPropertyParameter> PropertyParameters { get; set; }

        public string Value { get; set; }
        #endregion

       


        public void Serialize(TextWriter writer)
        {
            throw new NotImplementedException();
        }

        public IComponentProperty Deserialize(string value)
        {
            throw new NotImplementedException();
        }
    }
}
