using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ICalendar.GeneralInterfaces;
using System.Reflection;

namespace ICalendar.Factory
{
    public class CalendarComponentFactory : IFactory
    {
        public Dictionary<string, Type> _types { get; set; }
        private string _assemblyName = "ICalendar.CalendarComponents.";

        public ICalendarObject CreateIntance(string objSysName, string objName="")
        {
            var type = Type.GetType(_assemblyName + objSysName);
            if(type != null)
                return Activator.CreateInstance(type) as ICalendarComponent;
            return null;

        }

        public Type GetTypeToCreate(string objName)
        {
            if (_types.Keys.Contains(objName))
                return _types[objName];
            return null;
        }

        public void LoadAvailableTypes()
        {
            //_types = new Dictionary<string, Type>();            
            //var typesInAssembly = Assembly.Load("ICalendar.CalendarComponents").GetTypes();
            //foreach (var type in typesInAssembly)
            //{
            //    if (type.GetInterface(typeof(ICalendarComponent).ToString()) != null)
            //        _types.Add(type.Name.ToLower(), type);
            //}
        }
    }    
}
