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
        ///     Get the list that contains the RRules.
        /// </summary>
        /// <returns>All the RRules of the Component.</returns>
        List<IComponentProperty> GetRRules();

        /// <summary>
        ///     Get the list that contains the ATTENDEEs
        ///     of the component.
        /// </summary>
        /// <returns></returns>
        List<IComponentProperty> GetAttendees();

        /// <summary>
        ///     Convert the object in his iCalendar string representation.
        /// </summary>
        /// <param name="value">The values that should be represented.</param>
        /// <returns>Returns the string representation of the iCalendar component..</returns>
        string ToString(IEnumerable<string> value);

        #region Properties

        /// <summary>
        ///     Contains the RRULES properties of the component.
        /// </summary>
        List<IComponentProperty> RRules { get; set; }

        /// <summary>
        ///     Contains the ATTENDEE properties of the component.
        /// </summary>
        List<IComponentProperty> Attendees { get; set; }

        /// <summary>
        /// Returns the property of the component that
        /// has the given name. The HAVE to be one of the
        /// specifies in iCalendar protocol except 
        /// RRULES and ATTENDEES that may be defined multiple
        /// times.
        /// </summary>
        /// <param name="name">The iCalendar name of the property.</param>
        /// <returns></returns>
        IComponentProperty this[string name] { get; }
        #endregion
    }
}