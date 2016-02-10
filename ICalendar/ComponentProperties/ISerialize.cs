using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICalendar.ComponentProperties
{
    public interface ISerialize
    {


        void Serialize();

        IComponentProperty Deserialize();


    }
}
