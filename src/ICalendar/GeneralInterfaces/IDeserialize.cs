using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ICalendar.PropertyParameters;

namespace ICalendar.GeneralInterfaces
{
    public interface IDeserialize
    {
        IComponentProperty Deserialize(string value, List<PropertyParameter> parameters);
    }
}
