using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICalendar.ComponentProperties
{
    //TODO: change the signature to UTC-OFFSET
    public class Tzoffsetfrom : ComponentProperty<string>
    {
        public override string Name => "TZOFFSETFROM";
    }
}
