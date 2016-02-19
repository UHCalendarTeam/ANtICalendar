using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICalendar.GeneralInterfaces;

namespace ICalendar.ComponentProperties
{
    /// <summary>
    /// Calendar Components: VFREEBUSY;
    /// Value Type: PERIOD;
    /// Properties Parameters: iana, non-standard, free/busy time type
    /// </summary>
    public class FreeBusy : ComponentProperty<int>
    {
        public override string Name => "FREEBUSY";
    }
}
