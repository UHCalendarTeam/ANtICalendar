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
    /// Calendar Components: VTODO, VEVENT, VALARM;
    /// Value Type: DURATION;
    /// Properties Parameters: iana, non-standard
    /// </summary>
    public class Duration : ComponentProperty<int>
    {

        public new string Name => "DURATION";
       

    }
}
