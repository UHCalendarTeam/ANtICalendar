using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ICalendar.ComponentProperties.Unknown;
using ICalendar.GeneralInterfaces;

namespace ICalendar.Factory
{
    public class ComponentPropertyFactory : IFactory
    {
        public Dictionary<string, Type> _types { get; set; }
        private string _assemblyName = "ICalendar.ComponentProperties.";

        public ICalendarObject CreateIntance(string propSysName, string propName)
        {
            var type = Type.GetType(_assemblyName + propSysName);
            //if the property is one of the ICalendar protocol
            //the is defined in the system
            if(type!= null)
                return Activator.CreateInstance(type) as IComponentProperty;
            //if the property isn't define in the system
            //then it's a private property an is gonna be returned as 
            //an Unknown property
            
            return new Unknown { Name = propName };
        }

        public Type GetTypeToCreate(string objName)
        {
            throw new NotImplementedException();
        }

        public void LoadAvailableTypes()
        {
            throw new NotImplementedException();
        }
    }
}
