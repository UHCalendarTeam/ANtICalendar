namespace ICalendar.GeneralInterfaces
{
    /// <summary>
    ///     Defines the Value of the property.
    /// </summary>
    /// <typeparam name="T">
    ///     Depends on the type of content that the
    ///     property is gonna hold.
    /// </typeparam>
    public interface IValue<T>
    {
        /// <summary>
        ///     Contains the value of the property.
        ///     The type of the value depends on the
        ///     value that the property contains. This way
        ///     is much easier to manipulate the objects when
        ///     working with them.
        /// </summary>
        T Value { get; set; }
    }
}