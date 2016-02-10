using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICalendar.ComponentProperties.DateTime
{
    public class TimeTransparency:IComponentProperty, ISerialize
    {
        /*

        Calendar Components: VEVENT

        Value Type: TEXT

        Properties Parameters: iana, non-standard

        */

        public enum TransparencyValue
        {
            TRANSPARENT, OPAQUE
        }

        public string Name => "TRANSP";
        public void Serialize()
        {
            throw new NotImplementedException();
        }

        public IComponentProperty Deserialize()
        {
            throw new NotImplementedException();
        }

        public  TransparencyValue Value { get; }
    }
}
