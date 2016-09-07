using System;
using System.Text;

namespace ICalendar.ComponentProperties
{
    /// <summary>
    /// Purpose: This property defines the persistent, globally unique
    ///identifier for the calendar component.
    /// Conformance: The property MUST be specified in the "VEVENT",
    ///"VTODO", "VJOURNAL", or "VFREEBUSY" calendar components.
    /// </summary>
    public class Uid : ComponentProperty<string>
    {
        public override string Name => "UID";

        /// <summary>
        /// Generete the Uid for a CalendarComponent.
        /// This identifier is globally unique.
        /// </summary>
        public void Generate()
        {
            var str = new StringBuilder(DateTime.Now.ToString("yyyyMMddhhmmss")).
                Append(DateTime.Now.Millisecond).Append('@');

            //TODO: Add the right side( the domain of the current computer)
            Value = str.ToString();
        }
    }
}