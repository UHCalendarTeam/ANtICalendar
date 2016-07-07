using System.Collections.Generic;

namespace ICalendar.GeneralInterfaces
{
    /// <summary>
    ///     Define the behavior of the CalendarComponents objects.
    ///     ICalendarComponent object represents the iCalendar components:
    ///     VEVENT, VTODO, VTIMEZONE, VFREEBUSY, VJOURNAL, VALARAM, Standard and Daylight
    /// </summary>
    public interface ICalendarComponent : ISerialize, IComponentPropertiesContainer, IAggregator, ICalendarObject
    {
        /// <summary>
        ///     Returns a property by the given name.
        /// </summary>
        /// <param name="propName">Property name.</param>
        /// <returns>The property with the given name. </returns>
        IComponentProperty GetComponentProperty(string propName);

        /// <summary>
        ///     The iCalendar properties RRUES and
        ///     ATTENDEE may be defined multiple times
        ///     in a cal component so are returned as a list
        /// </summary>
        /// <param name="propName">"RRULE" || "ATTENDEE"</param>
        /// <returns>Multiple definition of one of this properties</returns>
        List<IComponentProperty> GetMultipleCompProperties(string propName);

        /// <summary>
        ///     Convert the object in his iCalendar string representation.
        /// </summary>
        /// <param name="value">The values that should be represented.</param>
        /// <returns>Returns the string representation of the iCalendar component..</returns>
        string ToString(IEnumerable<string> value);

        #region Properties

        /// <summary>
        ///     Contains the properties that might be defined
        ///     multiple times. These are RRULE | ATTENDEE | FREEBUSY
        /// </summary>
        Dictionary<string, List<IComponentProperty>> MultipleValuesProperties { get; set; }

        /// <summary>
        ///     Returns the property of the component that
        ///     has the given name. The HAVE to be one of the
        ///     specifies in iCalendar protocol except
        ///     RRULES and ATTENDEES that might be defined multiple
        ///     times.
        /// </summary>
        /// <param name="name">The iCalendar name of the property.</param>
        /// <returns></returns>
        IComponentProperty this[string name] { get; }

        #endregion Properties
    }
}