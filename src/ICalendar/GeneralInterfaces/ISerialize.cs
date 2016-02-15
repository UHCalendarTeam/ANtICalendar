using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICalendar.ComponentProperties
{
    public interface ISerialize<T>
    {
        void Serialize(System.IO.TextWriter writer);

        IComponentProperty<T> Deserialize(string value);

    }
}
