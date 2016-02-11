using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ICalendar.ComponentProperties.Alarm
{
    public class Action:IComponentProperty, ISerialize
    {
        /*

        Calendar Components: VALARM

        Value Type: TEXT

        Properties Parameters: iana, non-standard

        */

            public enum ActionValue
            {
                AUDIO, DISPLAY, EMAIL
            }

        public string Name => "ACTION";
        public void Serialize()
        {
            throw new NotImplementedException();
        }

        public IComponentProperty Deserialize()
        {
            throw new NotImplementedException();
        }

        public ActionValue Value { get; }
    }
}
