namespace ICalendar.ComponentProperties
{
    /// <summary>
    /// Calendar Components: VALARM;
    /// Value Type: INTEGER;
    /// Properties Parameters: iana, non-standard
    /// </summary>
    public class Repeat : ComponentProperty<int>
    {
        public override string Name => "REPEAT";
    }
}