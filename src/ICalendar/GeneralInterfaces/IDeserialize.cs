using ICalendar.PropertyParameters;
using System.Collections.Generic;

namespace ICalendar.GeneralInterfaces
{
    public interface IDeserialize
    {
        IComponentProperty Deserialize(string value, List<PropertyParameter> parameters);
    }
}