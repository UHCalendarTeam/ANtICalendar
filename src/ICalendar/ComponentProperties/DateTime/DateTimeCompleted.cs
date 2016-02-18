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
    /// Calendar Components: VTODO;
    /// Value Type: UTC;
    /// Properties Parameters: iana, non-standard
    /// </summary>
    public class DateTimeCompleted : ComponentProperty<System.DateTime>
    {
        public override string Name => "COMPLETED";
    }
}
