using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ICalendar.GeneralInterfaces;

namespace ICalendar.ComponentProperties
{
    /// <summary>
    /// Calendar Components: VFREEBUSY;
    /// Value Type: DATETIME/DATE/PERIOD;
    /// Properties Parameters: iana, non-standard, value data type, time zone identifier
    /// </summary>
    public class Rdate : ComponentProperty<IList<DateTime>>
    {
        public override string Name => "RDATE";

        
    }
}
