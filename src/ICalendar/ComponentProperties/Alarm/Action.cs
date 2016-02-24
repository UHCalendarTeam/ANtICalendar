using System.Collections.Generic;
using System.ComponentModel;
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
    public class Action : ComponentProperty<ActionValues.ActionValue>
    {
        public override string Name => "ACTION";
    }

    public class ActionValues
    {
        public enum ActionValue
        {
            AUDIO, DISPLAY, EMAIL
        }
        /// <summary>
        /// Convert an ActionValue to its string representation
        /// </summary>
        /// <param name="value"></param>
        /// <returns>ActionValue string representation</returns>
        public static string ToString(ActionValue value)
        {
            switch (value)
            {
                case ActionValue.AUDIO:
                    return "AUDIO";
                case ActionValue.DISPLAY:
                    return "DISPLAY";
                    case ActionValue.EMAIL:
                    return "EMAIL";
                default:
                    return "Not valid argument";
            }
        }
        /// <summary>
        /// Convert the string representation of
        /// an ActionValue to an ActionValue
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static ActionValue ParseValue(string value)
        {
            switch (value)
            {
                case "AUDIO":
                    return ActionValue.AUDIO;
                case "DISPLAY":
                    return ActionValue.DISPLAY;
                case "EMAIL":
                    return ActionValue.EMAIL;
                default:
                    return ActionValue.AUDIO;
            }
        }
    }
}
