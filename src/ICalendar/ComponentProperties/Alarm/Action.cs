using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ICalendar.ComponentProperties.Alarm
{
    /// <summary>
    /// Calendar Components: VALARM;
    /// Value Type: TEXT;
    /// Properties Parameters: iana, non-standard
    /// </summary>
    public class Action : IComponentProperty, ISerialize
    {
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
