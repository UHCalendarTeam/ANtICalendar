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
    /// Value Type: DATETIME/DATE;
    /// Properties Parameters: iana, non-standard, value data type, time zone identifier
    /// </summary>
    public class DateTimeDue : ComponentProperty<System.DateTime>
    {
        public new string Name => "DUE";
    }
}
