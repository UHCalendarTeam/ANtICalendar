using System;

namespace ICalendar.ComponentProperties
{
    //TODO: change the signature to UTC-OFFSET
    public class Tzoffsetto : ComponentProperty<TimeSpan>
    {
        public override string Name => "TZOFFSETTO";
    }
}