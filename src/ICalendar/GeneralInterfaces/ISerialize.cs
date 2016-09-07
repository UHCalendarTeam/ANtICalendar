using System.IO;

namespace ICalendar.GeneralInterfaces
{
    /// <summary>
    ///     Contains the definition for the method
    ///     that writes to a string the representation
    ///     of an object.
    /// </summary>
    public interface ISerialize
    {
        void Serialize(TextWriter writer);
    }
}