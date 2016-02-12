using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICalendar.ComponentProperties.ChangeManagement
{
    /// <summary>
    /// Calendar Components: VEVENT, VTODO, VJOURNAL;
    /// Value Type: INTEGER;
    /// Properties Parameters: iana, non-standard
    /// </summary>
    public class SequenceNumber : IComponentProperty, ISerialize
    {

        public string Name => "SEQUENCE";
        public void Serialize()
        {
            throw new NotImplementedException();
        }

        public IComponentProperty Deserialize()
        {
            throw new NotImplementedException();
        }

        public int Value { get; }
    }
}
