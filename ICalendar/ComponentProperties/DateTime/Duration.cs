using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICalendar.ComponentProperties.DateTime
{
    public class Duration: IComponentProperty, ISerialize
    {
        /*

        Calendar Components: VTODO, VEVENT, VALARM

        Value Type: DURATION

        Properties Parameters: iana, non-standard

        */

        public string Name => "DURATION";
        public void Serialize()
        {
            throw new NotImplementedException();
        }

        public IComponentProperty Deserialize()
        {
            throw new NotImplementedException();
        }


        //change this to duration type implement
        public  int Value { get; }

    }
}
