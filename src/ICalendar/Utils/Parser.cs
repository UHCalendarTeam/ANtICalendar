using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ICalendar.Calendar;
using ICalendar.CalendarComponents;
using ICalendar.GeneralInterfaces;
using ICalendar.PropertyParameters;
using ICalendar.Factory;

namespace ICalendar.Utils
{
    /// <summary>
    /// This class contains the necessary
    /// method to parse an ICalendar file.
    /// </summary>
    public static class Parser
    {
        /// <summary>
        /// Used to parse the components of the calendar
        /// </summary>
        /// <param name="reader">The reader  of the calendar</param>
        /// <param name="name">the name of the element to be parsed</param>
        /// <param name="parameters">the paramenters of the element to be parsed</param>
        /// <param name="value">the value of the element to be parsed</param>
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
            var speraratorIndex = line.IndexOfAny(new char[] { ':', ';' });
            name = line.Substring(0, speraratorIndex);

            //if the first separator is ';' then the line contains params values
            if (line[speraratorIndex] == ';')
            {
                
                var startValueIndex = line.IndexOfValues();
                parameters = line.Substring(speraratorIndex + 1, startValueIndex-speraratorIndex-1).ParamsParser();
                value = line.Substring(startValueIndex + 1);
            }
            else
                value = line.Substring(speraratorIndex + 1);


            //check if the name and value object are setted
            if (name==""||value=="")
            {
                return false;
                throw new ArgumentException("Component Properties MUST define the name and the value.");
                
            }
            return true;

        }

        /// <summary>
        /// Because the properties have to be splitted 
        /// if its lenght is bigger than 75 this method
        /// read lines till the end of the property
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>True if the line contains something, False otherwise</returns>
        private static string TakeLine(TextReader reader)
        {
            var output = new StringBuilder();
            var line = "";
            line = reader.ReadLine();
            if (string.IsNullOrEmpty(line))
                return "";


            while (line[line.Length - 1] == ' ' || line[line.Length - 1] == '\t')
            {
                line = reader.ReadLine();
            }
            output.Append(line);
            return output.ToString();
        }

        /// <summary>
        /// Parse a string than contains the parameters of a propterty
        /// </summary>
        /// <param name="strParams"></param>
        /// <returns>A list with the Name-Value of the params.</returns>
        public static List<PropertyParameter> ParamsParser(this string strParams)
        {
            var output = new List<PropertyParameter>();
            var paramsList = new List<string>();
            paramsList.AddRange(strParams.Split(';'));
            foreach (var parameter in paramsList)
            {
                var nameValue = parameter.Split('=');
                output.Add(new PropertyParameter(nameValue[0], nameValue[1]));
            }
            return output;
        }


       


        /// <summary>
        /// take the calendar string and prepare it for the processing
        /// </summary>
        /// <param name="calendar">Calendar string to build.</param>
        /// <returns>Splited lines of the calendar string.</returns>
        public static string[] CalendarReader(string calendar)
        {
            return calendar.Replace("\r\n ", "").Replace("\r", "").Split('\n');
          
        }


        
    }
}
