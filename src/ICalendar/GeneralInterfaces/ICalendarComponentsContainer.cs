using System.Collections.Generic;

namespace ICalendar.GeneralInterfaces
{
    /// <summary>
    ///     Container for the Calendar Components that the VCalendar
    ///     have. This cal Components are any of the defined in iCalendar.
    ///     SHOULD BE VTODO, VEVENT...
    /// </summary>
    public interface ICalendarComponentsContainer
    {
        /// <summary>
        ///     Key: Calendar Component name
        ///     Value: List with the Components (A calendar has many components).
        /// </summary>
        Dictionary<string, List<ICalendarComponent>> CalendarComponents { get; }
    }
}