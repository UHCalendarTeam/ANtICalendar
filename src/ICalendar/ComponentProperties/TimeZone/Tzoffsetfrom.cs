using System;

namespace ICalendar.ComponentProperties
{
    //TODO: change the signature to UTC-OFFSET
    public class Tzoffsetfrom : ComponentProperty<TimeSpan>
    {
        public override string Name => "TZOFFSETFROM";
    }
}