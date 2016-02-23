using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ICalendar.GeneralInterfaces;

namespace ICalendar.Factory
{
    public class ComponentPropertyFactory : IFactory
    {
        public Dictionary<string, Type> _types { get; set; }
        private string _assemblyName = "ICalendar.ComponentProperties.";

        public ICalendarObject CreateIntance(string objectName)
        {
            var type = Type.GetType(_assemblyName + objectName);
            return Activator.CreateInstance(type) as IComponentProperty;
            throw new NotImplementedException();
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
