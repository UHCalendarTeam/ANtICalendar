using ICalendar.GeneralInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICalendar.Factory
{
    public interface IFactory
    {
         Dictionary<string, Type> _types { get; set;}
    

    /// <summary>
    /// Create an instance of a Type with name
    /// given by objectName
    /// </summary>
    /// <param name="objectName">The name of the type to create.</param>
    /// <returns></returns>
    ICalendarObject CreateIntance(string objectName);

        /// <summary>
        /// Load the available types that the IFactory
        /// implementation can creates.
        /// </summary>
        void LoadAvailableTypes();

        /// <summary>
        /// Resolve and returns the type of the 
        /// object to be created.
        /// </summary>
        /// <param name="objName"></param>
        /// <returns></returns>
        Type GetTypeToCreate(string objName);
    }
}
