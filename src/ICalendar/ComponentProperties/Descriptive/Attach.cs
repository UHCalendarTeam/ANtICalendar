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
    public class Attach : ComponentProperty<string>
    {
        #region Properties
        public new string  Name => "ATTACH";
        #endregion
    }
}
