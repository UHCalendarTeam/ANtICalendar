using System.IO;
using System.Linq;
using System.Text;
using ICalendar.Calendar;
using ICalendar.CalendarComponents;
using ICalendar.Utils;
using TreeForXml;
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

        [Fact]
        public void UnitTest2()
        {
            var calStr = @"BEGIN:VCALENDAR
VERSION:2.0
PRODID:-//Example Corp.//CalDAV Client//EN
BEGIN:VFREEBUSY
ORGANIZER;CN=""Bernard Desruisseaux"":mailto:bernard@example.com
UID:76ef34-54a3d2@example.com
DTSTAMP:20050530T123421Z
DTSTART:20060101T100000Z
DTEND:20060108T100000Z
FREEBUSY;FBTYPE=BUSY-TENTATIVE:20060102T100000Z/20060102T120000Z
END:VFREEBUSY
END:VCALENDAR";
            var result = VCalendar.Parse(calStr);
        }

        /// <summary>
        /// Testing the toString with some comp and properties
        /// </summary>
        [Fact]
        public void UnitTest3()
        {
            var calStr = @"BEGIN:VCALENDAR
VERSION:2.0
PRODID:-//Example Corp.//CalDAV Client//EN
BEGIN:VTIMEZONE
LAST-MODIFIED:20040110T032845Z
TZID:US/Eastern
BEGIN:DAYLIGHT
DTSTART:20000404T020000
RRULE:FREQ=YEARLY;BYDAY=1SU;BYMONTH=4
TZNAME:EDT
TZOFFSETFROM:-0500
TZOFFSETTO:-0400
END:DAYLIGHT
BEGIN:STANDARD
DTSTART:20001026T020000
RRULE:FREQ=YEARLY;BYDAY=-1SU;BYMONTH=10
TZNAME:EST
TZOFFSETFROM:-0400
TZOFFSETTO:-0500
END:STANDARD
END:VTIMEZONE
BEGIN:VEVENT
ATTENDEE;PARTSTAT=ACCEPTED;ROLE=CHAIR:mailto:cyrus@example.com
ATTENDEE;PARTSTAT=NEEDS-ACTION:mailto:lisa@example.com
DTSTAMP:20060206T001220Z
DTSTART;TZID=US/Eastern:20060104T100000
DURATION:PT1H
RRULE:FREQ=YEARLY;BYDAY=-1SU;BYMONTH=10
LAST-MODIFIED:20060206T001330Z
ORGANIZER:mailto:cyrus@example.com
SEQUENCE:1
STATUS:TENTATIVE
SUMMARY:Event #3
UID:DC6C50A017428C5216A2F1CD@example.com
X-ABC-GUID:E1CX5Dr-0007ym-Hz@example.com
END:VEVENT
END:VCALENDAR";

            var result = VCalendar.Parse(calStr);

            var xmlStr = @"
<C:calendar-data xmlns:C=""urn:ietf:params:xml:ns:caldav"">
<C:comp name=""VCALENDAR"">
<C:prop name=""VERSION""/>
<C:comp name=""VEVENT"">
<C:prop name=""SUMMARY""/>
<C:prop name=""UID""/>
<C:prop name=""DTSTART""/>
<C:prop name=""DTEND""/>
<C:prop name=""DURATION""/>
<C:prop name=""RRULE""/>
<C:prop name=""ATTENDEE""/>
<C:prop name=""EXRULE""/>
<C:prop name=""EXDATE""/>
<C:prop name=""RECURRENCE-ID""/>
</C:comp>
<C:comp name=""VTIMEZONE""/>
</C:comp>
</C:calendar-data>";

            var calString = result.ToString(XmlTreeStructure.Parse(xmlStr));

        }







        [Fact]
        public void TestVConferenceComponent()
        {
            var vConfString = @"BEGIN:VCALENDAR
            VERSION:2.0
            PRODID:-//Example Corp.//CalDAV Client//EN
            BEGIN:VCONFERENCE
            DTSTAMP:20160206T001220Z
            DTSTART;TZID=US/Eastern:20160104T100000
            DURATION:PT1H30M
            SUMMARY:LP Conference
            UID:DC6C50A017428C5216A2F1CD@example.com
            RRULE:FREQ=WEEKLY;UNTIL=20161224T000000Z
            END:VCONFERENCE
            END:VCALENDAR
            ";
            var vConference = VCalendar.Parse(vConfString);
            var stringVConf = vConference.ToString();

            Assert.Equal(vConfString,stringVConf);
        }
        










    }
}