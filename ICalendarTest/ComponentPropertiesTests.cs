using ICalendar.Utils;
using ICalendar.ValueTypes;
using Xunit;

namespace ICalendarTest
{
    /// <summary>
    /// This class contains tests for the ComponentProperties.
    /// </summary>
    public class ComponentPropertiesTests
    {
        /// <summary>
        /// Testing the Recur objects.
        /// </summary>
        [Fact]
        public void UnitTest1()
        {
            Recur recur;
            "RRULE:FREQ=MONTHLY;UNTIL=19971224T000000Z;BYDAY=1FR".ToRecur(out recur);
            Assert.Equal(recur.Frequency.Value, RecurValues.Frequencies.MONTHLY);

            "RRULE:FREQ=DAILY;UNTIL=19971224T000000Z;BYDAY=1FR".ToRecur(out recur);
            Assert.Equal(recur.Frequency.Value, RecurValues.Frequencies.DAILY);

            "RRULE:FREQ=WEEKLY;UNTIL=19971224T000000Z;BYDAY=1FR".ToRecur(out recur);
            Assert.Equal(recur.Frequency.Value, RecurValues.Frequencies.WEEKLY);

            "RRULE:FREQ=YEARLY;UNTIL=19971224T000000Z;BYDAY=1FR".ToRecur(out recur);
            Assert.Equal(recur.Frequency.Value, RecurValues.Frequencies.YEARLY);

            "RRULE:FREQ=MINUTELY;UNTIL=19971224T000000Z;BYDAY=1FR".ToRecur(out recur);
            Assert.Equal(recur.Frequency.Value, RecurValues.Frequencies.MINUTELY);

            "RRULE:FREQ=MINUTELY;UNTIL=19971224T000000Z;BYDAY=1FR".ToRecur(out recur);
            Assert.Equal(recur.Frequency.Value, RecurValues.Frequencies.MINUTELY);

            "RRULE:FREQ=HOURLY;UNTIL=19971224T000000Z;BYDAY=1FR".ToRecur(out recur);
            Assert.Equal(recur.Frequency.Value, RecurValues.Frequencies.HOURLY);
        }
    }
}