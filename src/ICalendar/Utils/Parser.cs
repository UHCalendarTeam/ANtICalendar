using System.Collections.Generic;
using System.Linq;
using ICalendar.PropertyParameters;

namespace ICalendar.Utils
{
    /// <summary>
    ///     This class contains the necessary
    ///     methods to parse an ICalendar file and build
    ///     our objects that represent them.
    /// </summary>
    public static class Parser
    {
        /// <summary>
        ///     Used to parse each line in the iCal definition.
        ///     Return by reference the values of the name, value and
        ///     params of the parsed line.
        /// </summary>
        /// <param name="line">The line of the iCal to be parse.</param>
        /// <param name="name">The name of the parsed element.</param>
        /// <param name="parameters">The params of the parsed element</param>
        /// <param name="value">The value of the parsed element.</param>
        /// <returns>Return true if the line is not empty, false otherwise.</returns>
        public static bool CalendarParser(string line,
            out string name, out List<PropertyParameter> parameters, out string value)
        {
            //var line = TakeLine(reader);
            name = "";
            parameters = new List<PropertyParameter>();
            value = "";
            if (line == "")
            {
                //it means there's nothing else in the file
                //so return 
                return false;
            }

            //from the begining of the line till the index of these chars
            //has to be the name
            var speraratorIndex = line.IndexOfAny(new[] {':', ';'});
            name = line.Substring(0, speraratorIndex);

            //if the first separator is ';' then the line contains params values
            if (line[speraratorIndex] == ';')
            {
                var startValueIndex = line.IndexOfValues();
                parameters = line.Substring(speraratorIndex + 1, startValueIndex - speraratorIndex - 1).ParamsParser();
                value = line.Substring(startValueIndex + 1);
            }
            else
                value = line.Substring(speraratorIndex + 1);


            //check if the name and value object are setted
            return name != "" && value != "";
        }


        /// <summary>
        ///     Parse a string than contains the params of a property.
        /// </summary>
        /// <param name="strParams">The string that contains the params declaration</param>
        /// <returns>A list with the Name-Value of the params.</returns>
        public static List<PropertyParameter> ParamsParser(this string strParams)
        {
            var paramsList = new List<string>();
            paramsList.AddRange(strParams.Split(';'));
            return
                paramsList.Select(parameter => parameter.Split('='))
                    .Select(nameValue => new PropertyParameter(nameValue[0], nameValue[1]))
                    .ToList();
        }


        /// <summary>
        ///     take the calendar string and prepare it for the processing
        /// </summary>
        /// <param name="calendar">Calendar string to build.</param>
        /// <returns>Splited lines of the calendar string.</returns>
        public static string[] CalendarReader(string calendar)
        {
            return calendar.Replace("\r\n ", "").Replace("\r", "").Split('\n');
        }
    }
}