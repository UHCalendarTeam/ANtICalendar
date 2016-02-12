using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICalendar.ComponentProperties.DateTime
{
    /// <summary>
    /// Calendar Components: VEVENT;
    /// Value Type: TEXT;
    /// Properties Parameters: iana, non-standard
    /// </summary>
    public class TimeTransparency : IComponentProperty, ISerialize
    {

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

        public TransparencyValue Value { get; }
    }
}
