using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICalendar.ComponentProperties.ChangeManagement
{
    public class DateTimeCreated: IComponentProperty, ISerialize
    {
        /*

        Calendar Components: VEVENT, VTODO, VJOURNAL

        Value Type: DATETIME

        Properties Parameters: iana, non-standard

        */

        public string Name => "CREATED";
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
