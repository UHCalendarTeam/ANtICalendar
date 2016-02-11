using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICalendar.ComponentProperties.ChangeManagement
{
    public class DateTimeStamp: IComponentProperty, ISerialize
    {
        /*

        Calendar Components: VEVENT, VTODO, VJOURNAL, VFREEBUSY (MUST BE INCLUDED IN ALL)

        Value Type: DATETIME

        Properties Parameters: iana, non-standard

        */

        public string Name => "DTSTAMP";
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
