using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICalendar.ComponentProperties.ChangeManagement
{
    /// <summary>
    /// Calendar Components: VEVENT, VTODO, VJOURNAL, VTIMEZONE;
    /// Value Type: DATETIME;
    /// Properties Parameters: iana, non-standard
    /// </summary>
    public class LastModified : IComponentProperty, ISerialize
    {
        public string Name => "LAST-MODIFIED";
        public void Serialize()
        {
            throw new NotImplementedException();
        }

        public IComponentProperty Deserialize()
        {
            throw new NotImplementedException();
        }

        public System.DateTime Value { get; }
    }
}
