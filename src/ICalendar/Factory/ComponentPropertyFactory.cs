using System;
using ICalendar.ComponentProperties.Unknown;
using ICalendar.GeneralInterfaces;

namespace ICalendar.Factory
{
    public class ComponentPropertyFactory : IFactory
    {
        /// <summary>
        ///     The assembly name where are defined the Properties.
        /// </summary>
        private readonly string _assemblyName = "ICalendar.ComponentProperties.";

        /// <summary>
        ///     Returns the object that represent the iCalendar
        ///     property with name equal to the given.
        /// </summary>
        /// <param name="propSysName"></param>
        /// <param name="propName"></param>
        /// <returns></returns>
        public ICalendarObject CreateIntance(string propSysName, string propName)
        {
            ///if the name of the object is one 
            /// of the specified in the iCalendar protocol
            /// the process it to get its equivalent name
            /// of this system.
            if (propSysName.Contains("-"))
            {
                propSysName = propSysName.Replace("-", "_");
                propSysName = propSysName.Substring(0, 1) + propSysName.Substring(1).ToLower();
            }

            var type = Type.GetType(_assemblyName + propSysName);
            ///if the property is one of the ICalendar protocol
            /// properties and is is defined in the system
            if (type != null)
                return Activator.CreateInstance(type) as IComponentProperty;

            //if the property isn't define in the system
            //then it's a private property an is gonna be returned as 
            //an Unknown property

            return new Unknown {Name = propName};
        }
    }
}