using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICalendar.ComponentProperties
{
    public class Attach : IComponentProperty, ISerialize
    {
        public string Name
        {
            get{ return "ATTACH";}          
        }

        IComponentProperty ISerialize.Deserialize()
        {
            throw new NotImplementedException();
        }

        void ISerialize.Serialize()
        {
            throw new NotImplementedException();
        }
    }
}
