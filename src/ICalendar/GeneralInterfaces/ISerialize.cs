using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ICalendar.ComponentProperties;

namespace ICalendar.GeneralInterfaces
{
    public interface ISerialize
    {
        void Serialize(System.IO.TextWriter writer);

    }
}
