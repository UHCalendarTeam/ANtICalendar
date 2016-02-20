using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ICalendar.ComponentProperties;

namespace ICalendar.CalendarProperties
{
    public class Method : ComponentProperty<string>
    {
        public override string Name => "METHOD";
    }
}
