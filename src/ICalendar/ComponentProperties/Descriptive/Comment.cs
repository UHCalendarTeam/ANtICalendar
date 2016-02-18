using System.Collections.Generic;
using System.IO;
using ICalendar.GeneralInterfaces;
using static ICalendar.Utils.Utils;

namespace ICalendar.ComponentProperties
{
    public class Comment: ComponentProperty<string>
    {
        public new string Name => "COMMENT";
    }
}
