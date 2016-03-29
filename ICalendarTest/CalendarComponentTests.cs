using System.IO;
using System.Text;
using ICalendar.Calendar;
using ICalendar.Utils;
using Xunit;

namespace ICalendarTest
{
    /// <summary>
    /// This class contains test for the CalendarComponents.
    /// </summary>
    public class CalendarComponentTests
    {
        /// <summary>
        /// Testing the creation of VFREEBUSY components.
        /// </summary>
        [Fact]
        public void UnitTest1()
        {
            var calString = @"BEGIN:VCALENDAR
BEGIN:VFREEBUSY
FREEBUSY:19980314T233000Z/19980315T003000Z
FREEBUSY:19980316T153000Z/19980316T163000Z
FREEBUSY:19980318T030000Z/19980318T040000Z
URL:http://www.example.com/calendar/busytime/jsmith.ifb
END:VFREEBUSY
END:VCALENDAR
";
            VCalendar calendar = VCalendar.Parse(calString);
            var calendarString = calendar.ToString();
            UnicodeEncoding uniencoding = new UnicodeEncoding();
            UTF8Encoding utf8Encoding = new UTF8Encoding();
            var toWrite = utf8Encoding.GetBytes(calendarString);
            File.Delete("output1.ics");
            using (var writer = File.OpenWrite("output1.ics"))
            {
                writer.Seek(0, SeekOrigin.End);
                writer.Write(toWrite, 0, toWrite.Length);
            }
            using (var reader = File.OpenText("output1.ics"))
            {
                var writedCal = reader.ReadToEnd();
                var writedCalLines = Parser.CalendarReader(writedCal);
                var expectedLines = Parser.CalendarReader(calString);
                Assert.Equal(expectedLines.Length, writedCalLines.Length);
                for (int i = 0; i < writedCalLines.Length; i++)
                {
                    Assert.Contains(expectedLines[i], writedCalLines);
                }
            }
            Assert.NotNull(calendarString);
        }
    }
}