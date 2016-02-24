using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICalendar.ComponentProperties
{
    //TODO: change the signature to UTC-OFFSET
    public class Tzoffsetto : ComponentProperty<TimeSpan>
    {
        public override string Name => "TZOFFSETTO";
    }
}
