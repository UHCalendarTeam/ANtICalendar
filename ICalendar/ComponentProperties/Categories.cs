using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICalendar.ComponentProperties
{
    class Categories:IComponentProperty, ISerialize
    {
        public string Name => "CATEGORIES";

        public void Serialize()
        {
            throw new NotImplementedException();
        }

        public IComponentProperty Deserialize()
        {
            throw new NotImplementedException();
        }
    }
}
