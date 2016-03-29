namespace ICalendar.ComponentProperties
{
    /// <summary>
    /// Purpose: This property is used to represent a relationship or
    ///reference between one calendar component and another.
    /// </summary>
    public class Related_to : ComponentProperty<string>
    {
        public override string Name => "RELATED-TO";
    }
}