using System;
using ICalendar.GeneralInterfaces;

namespace ICalendar.Factory
{
    /// <summary>
    ///     Factory for the building of CalendarComponent objects.
    /// </summary>
    public class CalendarComponentFactory : IFactory
    {
        /// <summary>
        ///     The assembly where are defined the Properties of the cal components.
        /// </summary>
        private readonly string _assemblyName = "ICalendar.CalendarComponents.";

        /// <summary>
        ///     Creates an intences of the spicified type
        ///     using the default contructor.
        /// </summary>
        /// <param name="objSysName">The name of the object.</param>
        /// <param name="objName"></param>
        /// <returns></returns>
        public ICalendarObject CreateIntance(string objSysName, string objName = "")
        {
            var type = Type.GetType(_assemblyName + objSysName);
            if (type != null)
                return Activator.CreateInstance(type) as ICalendarComponent;
            return null;
        }
    }
}