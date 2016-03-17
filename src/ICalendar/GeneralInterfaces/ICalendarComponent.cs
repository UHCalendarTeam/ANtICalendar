using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ICalendar.CalendarComponents;
using ICalendar.ComponentProperties;
using ICalendar.GeneralInterfaces;

namespace ICalendar.GeneralInterfaces
{
    /// <summary>
    /// The abstraction of the CalendarComponents implementations.
    /// </summary>
    public interface ICalendarComponent:ISerialize, IComponentPropertiesContainer, IAggregator, ICalendarObject
    {
        /// <summary>
        /// Return the property by the given name.
        /// </summary>
        /// <param name="propName">Property name.</param>
        /// <returns>The property with the given name. </returns>
        IComponentProperty GetComponentProperty(string propName);

        /// <summary>
        /// Get the list that contain the RRules.
        /// </summary>
        /// <returns>All the RRules of the Component.</returns>
         List<IComponentProperty> GetRRules();
        
        string ToString(List<string> value);
    }
}
