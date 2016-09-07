namespace ICalendar.GeneralInterfaces
{
    public interface IPropertyParameter
    {
        string Name { get; }

        string Value { get; set; }
    }
}