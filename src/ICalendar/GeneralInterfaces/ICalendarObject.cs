namespace ICalendar.GeneralInterfaces
{
    /// <summary>
    ///     Represent a .NET object of an iCalendar
    ///     component.
    /// </summary>
    public interface ICalendarObject
    {
        /// <summary>
        /// The name like the protocol says of the iCalendar object.
        /// </summary>
        string Name { get; }
    }
}