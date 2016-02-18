using System;
using System.Collections.Generic;
using System.IO;
using ICalendar.GeneralInterfaces;
using ICalendar.Utils;

namespace ICalendar.ComponentProperties
{
    /// <summary>
    /// Calendar Components: VALARM;
    /// Value Type: INTEGER;
    /// Properties Parameters: iana, non-standard
    /// </summary>
    public class RepeatCount : ComponentProperty<int>
    {

        public override string Name => "REPEAT";
           
       

    }
}
