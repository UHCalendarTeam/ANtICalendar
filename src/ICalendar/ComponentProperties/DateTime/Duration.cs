using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICalendar.ComponentProperties.DateTime
{
    /// <summary>
    /// Calendar Components: VTODO, VEVENT, VALARM;
    /// Value Type: DURATION;
    /// Properties Parameters: iana, non-standard
    /// </summary>
    public class Duration : IComponentProperty, ISerialize
    {

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
        public int Value { get; }

    }
}
