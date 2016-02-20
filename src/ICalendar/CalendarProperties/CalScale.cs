using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ICalendar.ComponentProperties;

namespace ICalendar.ComponentProperties
{
    public class Calscale: ComponentProperty<string>
    {
        public override string Name => "CALSCALE";
    }
}
