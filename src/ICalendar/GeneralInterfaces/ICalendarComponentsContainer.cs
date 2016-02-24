using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICalendar.GeneralInterfaces
{
    /// <summary>
    /// Container for the Calendar Components that the VCalendar
    /// have.
    /// </summary>
    public interface ICalendarComponentsContainer
    {
        /// <summary>
        /// Key: Calendar Components name
        /// Value: List with the Components (A calendar has many components).
        /// </summary>
         IDictionary<string,IList<ICalendarComponent>> CalendarComponents { get;  }
    }
}
