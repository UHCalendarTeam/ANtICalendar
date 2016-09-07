using ICalendar.GeneralInterfaces;

namespace ICalendar.Factory
{
    public interface IFactory
    {
        /// <summary>
        ///     Create an instance of a Type with the same name
        ///     given by objectName
        /// </summary>
        /// <param name="objectName">The name of the type to create.</param>
        /// <returns></returns>
        ICalendarObject CreateIntance(string objectName, string propName = "");
    }
}