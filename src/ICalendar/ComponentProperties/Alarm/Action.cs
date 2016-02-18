using System.Collections.Generic;
using System.IO;
using ICalendar.GeneralInterfaces;
using ICalendar.Utils;


namespace ICalendar.ComponentProperties
{
    /// <summary>
    /// Calendar Components: VALARM;
    /// Value Type: TEXT;
    /// Properties Parameters: iana, non-standard
    /// </summary>
    public class Action : IComponentProperty, IValue<Action.ActionValue>
    {
        public enum ActionValue
        {
            AUDIO, DISPLAY, EMAIL
        }

        public string Name => "ACTION";

        public IList<IPropertyParameter> PropertyParameters { get; set; }

        public void Serialize(TextWriter writer)
        {
            writer.WriteLine(this.StringRepresentation());
        }

        public IComponentProperty Deserialize(string value)
        {
            value = value.ValuesSubString();
            switch (value)
            {
                case "AUDIO":
                    Value = ActionValue.AUDIO;
                    break;
                case "DISPLAY":
                    Value = ActionValue.DISPLAY;
                    break;
                case "EMAIL":
                    Value = ActionValue.EMAIL;
                    break;
                default:
                    Value = ActionValue.DISPLAY;
                    break;

            }


            return this;
        }

        public ActionValue Value { get; set; }
        
    }
}
