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
        public static bool CalendarParser(TextReader reader,
            out string name, out List<PropertyParameter> parameters, out string value)
        {
            var line = TakeLine(reader);
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
            var indexName = line.IndexOfAny(new char[] { ':', ';' });
            name = line.Substring(0, indexName);

            //if the first separator is ';' then the line contains params values
            if (line[indexName] == ';')
            {
                var indexParams = line.LastIndexOf(':');
                parameters = line.Substring(indexName + 1, indexParams-indexName-1).ParamsParser();
                value = line.Substring(indexParams + 1);
            }
            else
                value = line.Substring(indexName + 1);


            //check if the name and value object are setted
            if (name==""||value=="")
            {
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
            if (line != null && line.Length < 1)
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
        /// Call the parser and makes the instace of the 
        /// CalendarComponents and ComponentProperties dinamically
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        //public static VCalendar CalendarBuilder(TextReader reader)
        //{
        //    //used to create the instances of the objects dinamically
        //    var assemblyNameCalCmponents = "ICalendar.CalendarComponents.";
        //    var assemblyNamePropCompoments = "ICalendar.ComponentProperties.";
        //    var assemblyNameCalendar = "ICalendar.Calendar.";            
        //    string name = "";
        //    string value = "";
        //    List<PropertyParameter> parameters = new List<PropertyParameter>();
        //    object calComponent = null;
        //    object compProperty = null;
        //    Stack<object> objStack = new Stack<object>();
        //    Type type=null;
        //    while (CalendarParser(reader, out name, out parameters, out value))
        //    {
        //        //TODO: Do the necessary with the objects that dont belong to CompProperties
        //        if (name == "BEGIN")
        //        {
        //            var className = value;
        //            className = className.Substring(0, 2) + className.Substring(2).ToLower();
        //            if (value=="VCALENDAR")
        //                type = Type.GetType(assemblyNameCalendar + className);
        //            else
        //                type = Type.GetType(assemblyNameCalCmponents + className);

        //            calComponent = Activator.CreateInstance(type);
        //            objStack.Push(calComponent);                                       
        //            continue;

        //        }
        //        if (name == "END")
        //        {
        //            var endedObject = objStack.Pop();
        //             if (endedObject is VCalendar)                    
        //                return (VCalendar)endedObject;
        //            ((IAggregator)objStack.Peek()).AddItem(endedObject);                  
        //            continue;
        //        }

        //        if (name.Contains("-"))
        //            name=name.Replace("-", "_");
        //        var propName = name.Substring(0, 1) + name.Substring(1).ToLower();
        //        type = Type.GetType(assemblyNamePropCompoments + propName);
        //        //if come an iana property that we dont recognize
        //        //so dont do anything with it
        //        try
        //        {
        //            compProperty = Activator.CreateInstance(type);
        //        }
        //        catch (System.Exception)
        //        {                    
        //            continue;
        //        }

        //        var topObj = objStack.Peek();
        //        ((IAggregator)topObj).AddItem(((IDeserialize)compProperty).Deserialize(value, parameters));


        //    }
        //    throw new ArgumentException("The calendar file MUST contain at least an element.");
        //}

        /// <summary>
        /// Call the parser and makes the instace of the 
        /// CalendarComponents and ComponentProperties dinamically
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static VCalendar CalendarBuilder(TextReader reader)
        {
            //used to create the instances of the objects dinamically
            var calCompFactory = new CalendarComponentFactory();
            var compPropFactory = new ComponentPropertyFactory();
            var assemblyNameCalendar = "ICalendar.Calendar.";
            string name = "";
            string value = "";
            List<PropertyParameter> parameters = new List<PropertyParameter>();
            ICalendarObject calComponent = null;
            ICalendarObject compProperty = null;
            Stack<ICalendarObject> objStack = new Stack<ICalendarObject>();
            Type type = null;
            while (CalendarParser(reader, out name, out parameters, out value))
            {
                //TODO: Do the necessary with the objects that dont belong to CompProperties
                if (name == "BEGIN")
                {
                    var className = value;
                    className = className.Substring(0, 2) + className.Substring(2).ToLower();
                    if (value == "VCALENDAR")
                    {
                        type = Type.GetType(assemblyNameCalendar + className);
                        calComponent = Activator.CreateInstance(type) as ICalendarObject;
                    }
                    else
                        calComponent = calCompFactory.CreateIntance(className);

                   
                    objStack.Push(calComponent);
                    continue;

                }
                if (name == "END")
                {
                    var endedObject = objStack.Pop();
                    if (endedObject is VCalendar)
                        return (VCalendar)endedObject;
                    ((IAggregator)objStack.Peek()).AddItem(endedObject);
                    continue;
                }

                if (name.Contains("-"))
                    name = name.Replace("-", "_");
                var propName = name.Substring(0, 1) + name.Substring(1).ToLower();
                compProperty = compPropFactory.CreateIntance(propName);
                if (compProperty == null)
                    continue;
                //if come an iana property that we dont recognize
                //so dont do anything with it
                //try
                //{
                //    compProperty = Activator.CreateInstance(type);
                //}
                //catch (System.Exception)
                //{
                //    continue;
                //}

                var topObj = objStack.Peek();
                ((IAggregator)topObj).AddItem(((IDeserialize)compProperty).Deserialize(value, parameters));


            }
            throw new ArgumentException("The calendar file MUST contain at least an element.");
        }
    }
}
