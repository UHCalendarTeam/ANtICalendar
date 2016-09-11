using System;
using ICalendar.PropertyParameters;
using System.Collections.Generic;
using System.Linq;
using ICalendar.Calendar;
using ICalendar.Factory;
using ICalendar.GeneralInterfaces;

namespace ICalendar.Utils
{
    /// <summary>
    ///     Contains some useful methods to parse the icalendar files.
    /// </summary>
    public static class Parser
    {


        /// <summary>
        ///     Parse the text that contains the iCalendar representation.
        ///     Create an instance of VCALENDAR object with all the calendar components
        ///     and properties.
        /// </summary>
        /// <param name="calendarString">The calendar representation to be parsed.</param>
        /// <returns>The VCaledar instance.</returns>
        public static VCalendar iCalendarParser(string calendarString)
        {
            //used to create instance of calendar component objects
            var calCompFactory = new CalendarComponentFactory();

            //used to create instance of component property objects
            var compPropFactory = new ComponentPropertyFactory();
            var objStack = new Stack<ICalendarObject>();

            var lines = CalendarReader(calendarString);

            foreach (var line in lines)
            {
                List<PropertyParameter> parameters;
                string lineValue;

                string firstLineString;
                if (!LineParser(line, out firstLineString, out parameters, out lineValue))
                    continue;
                switch (firstLineString)
                {
                    case "BEGIN":


                        ///if the component is vcalendar then create is
                        /// if not then call the factory to get the object
                        /// that name.
                        var calComponent = lineValue == "VCALENDAR" ? new VCalendar() : calCompFactory.CreateIntance(lineValue);
                        objStack.Push(calComponent);
                        continue;
                    case "END":
                        var endedObject = objStack.Pop();
                        //if the last object in the stack is an VCalendar then
                        //is the end of the parsing
                        var vCalendar = endedObject as VCalendar;
                        if (vCalendar != null)
                            return vCalendar;

                        ///if the object is not a VCalendar means
                        /// that should be added to his father that
                        /// is the first in the stack
                        ((IAggregator)objStack.Peek()).AddItem(endedObject);
                        continue;
                }
                ///creates an instance of a property
                var compProperty = compPropFactory.CreateIntance(firstLineString, firstLineString);

                var topObj = objStack.Peek();
                //set the value and params in the compProperty via the Deserializer of the property
                ((IAggregator)topObj).AddItem(((IDeserialize)compProperty).Deserialize(lineValue, parameters));
            }

            throw new ArgumentException("The calendar file MUST contain at least an element.");
        }




        /// <summary>
        ///     Parse a line of the iCalendar file definition.
        ///     Return by reference the values of the name, value and
        ///     params of the parsed line.
        /// </summary>
        /// <param name="line">The line of the iCal to be parse.</param>
        /// <param name="name">The name of the parsed element.</param>
        /// <param name="parameters">The params of the parsed element</param>
        /// <param name="value">The value of the parsed element.</param>
        /// <returns>Return true if the line is not empty, false otherwise.</returns>
        public static bool LineParser(string line,
            out string name, out List<PropertyParameter> parameters, out string value)
        {
            //var line = TakeLine(reader);
            name = "";
            parameters = new List<PropertyParameter>();
            value = "";

            //if the line is empty with reach the end
            if (line == "")
                return false;
           

            //from the begining of the line till the index of these chars
            //has to be the name
            var speraratorIndex = line.IndexOfAny(new[] { ':', ';' });
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
        ///     Parse a line and take the params from it.
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