using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ICalendar.ComponentProperties;
using ICalendar.GeneralInterfaces;

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
        public static bool CalendarParser(TextReader reader, 
            out string name, out List<PropertyParameters> parameters, out string value)
        {
            var line = TakeLine(reader);
            int indexParams = 0;
            int indexName = 0;
            name = "";
            parameters = new List<PropertyParameters>();
            value = "";
            if (line == "")
            {
                //it means there's nothing else in the file
                //so return 
                return false;
            }
            
            //from the begining of the line till the index of these chars
            //has to be the name
            indexName = line.IndexOfAny(new char[] { ',', ';' });
            name = line.Substring(0, indexName);

            //if the first separator is ';' then it means the line contains params values
            if (line[indexName] == ';')
            {
                indexParams = line.LastIndexOf(':');
                parameters = line.Substring(indexName + 1, indexParams).ParamsParser();
            }
            value = line.Substring(indexParams + 1);

            //check if the name and value object are setted
            return true;

        }

        /// <summary>
        /// Because the properties have to be splitted 
        /// if its lenght is bigger than 75 this method
        /// read lines till the end of the property
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>True if the line contains something, False otherwise</returns>
        static string TakeLine(TextReader reader)
        {
            var output = new StringBuilder();
            var line = "";
            line = reader.ReadLine();
            if (line.Length < 1)
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
        public static List<PropertyParameters> ParamsParser(this string strParams)
        {
            var output = new List<PropertyParameters>();
            var paramsList = new List<string>();
            paramsList.AddRange(strParams.Split(','));
            foreach (var parameter in paramsList)
            {
                var nameValue = parameter.Split('=');
                output.Add(new PropertyParameters(nameValue[0], nameValue[1]));
            }
            return output;
        }



        public static ICalendarComponent ComponentMaker(TextReader reader)
        {
            //used to create the instances of the objects dinamically
            var assemblyName = "ICalendar.ComponentProperties";
            string name = "";
            string value = "";
            List<PropertyParameters> parameters = new List<PropertyParameters>();
            while (CalendarParser(reader, out name, out parameters, out value))
            {
                //TODO: Do the necessary with the objects that dont belong to CompProperties
                if (name == "BEGIN")
                {
                   // var obj = Activator.CreateInstanceFrom(assemblyName, value);
                }

            }
            return null;
        }
    }
}
