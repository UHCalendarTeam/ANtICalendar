using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ICalendar;
using ICalendar.Calendar;
using ICalendar.CalendarComponents;
using ICalendar.GeneralInterfaces;
using ICalendar.Utils;
using TreeForXml;

namespace ICalendarTest
{
	// This project can output the Class library as a NuGet Package.
	// To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
	public class Class1
	{

		[Fact]
		public void BuildVCalendar()
		{
			var calString = @"BEGIN:VCALENDAR
PRODID:-//Google Inc//Google Calendar 70.9054//EN
VERSION:2.0
CALSCALE:GREGORIAN
X-WR-CALNAME:calmozilla1@gmail.com
X-WR-TIMEZONE:America/Los_Angeles
BEGIN:VTIMEZONE
TZID:America/Los_Angeles
X-LIC-LOCATION:America/Los_Angeles
BEGIN:DAYLIGHT
TZOFFSETFROM:-0800
TZOFFSETTO:-0700
TZNAME:PDT
DTSTART:19700308T020000
RRULE:FREQ=YEARLY;BYDAY=2SU;BYMONTH=3
END:DAYLIGHT
BEGIN:STANDARD
TZOFFSETFROM:-0700
TZOFFSETTO:-0800
TZNAME:PST
DTSTART:19701101T020000
RRULE:FREQ=YEARLY;BYDAY=1SU;BYMONTH=11
END:STANDARD
END:VTIMEZONE
BEGIN:VEVENT
DTSTART;TZID=America/Los_Angeles:20120629T130000
DTEND;TZID=America/Los_Angeles:20120629T140000
DTSTAMP:20120629T112428Z
UID:0kusnhnnacaok1r02v16simh8c@google.com
CREATED:20120629T111935Z
DESCRIPTION:foo
LAST-MODIFIED:20120629T112428Z
LOCATION:Barcelona
SEQUENCE:0
STATUS:CONFIRMED
SUMMARY:Demo B2G Calendar
TRANSP:OPAQUE
BEGIN:VALARM
ACTION:EMAIL
DESCRIPTION:This is an event reminder
SUMMARY:Alarm notification
ATTENDEE:mailto:calmozilla1@gmail.com
TRIGGER:-P0DT0H30M0S
END:VALARM
BEGIN:VALARM
ACTION:DISPLAY
DESCRIPTION:This is an event reminder
TRIGGER:-P0DT0H30M0S
END:VALARM
END:VEVENT
END:VCALENDAR
";
			VCalendar calendar = new VCalendar(calString);
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
		public void CheckProperties()
		{
			var calString = @"BEGIN:VCALENDAR
PRODID:-//Google Inc//Google Calendar 70.9054//EN
VERSION:2.0
CALSCALE:GREGORIAN
X-WR-CALNAME:calmozilla1@gmail.com
X-WR-TIMEZONE:America/Los_Angeles
BEGIN:VTIMEZONE
TZID:America/Los_Angeles
X-LIC-LOCATION:America/Los_Angeles
BEGIN:DAYLIGHT
TZOFFSETFROM:-0800
TZOFFSETTO:-0700
TZNAME:PDT
DTSTART:19700308T020000
RRULE:FREQ=YEARLY;BYMONTH=3;BYDAY=2SU
END:DAYLIGHT
BEGIN:STANDARD
TZOFFSETFROM:-0700
TZOFFSETTO:-0800
TZNAME:PST
DTSTART:19701101T020000
RRULE:FREQ=YEARLY;BYMONTH=11;BYDAY=1SU
END:STANDARD
END:VTIMEZONE
BEGIN:VEVENT
DTSTART;TZID=America/Los_Angeles:20120629T130000
DTEND;TZID=America/Los_Angeles:20120629T140000
DTSTAMP:20120629T112428Z
UID:0kusnhnnacaok1r02v16simh8c@google.com
CREATED:20120629T111935Z
DESCRIPTION:foo
LAST-MODIFIED:20120629T112428Z
LOCATION:Barcelona
SEQUENCE:0
STATUS:CONFIRMED
SUMMARY:Demo B2G Calendar
TRANSP:OPAQUE
BEGIN:VALARM
ACTION:EMAIL
DESCRIPTION:This is an event reminder
SUMMARY:Alarm notification
ATTENDEE:mailto:calmozilla1@gmail.com
TRIGGER:-P0DT0H30M0S
END:VALARM
BEGIN:VALARM
ACTION:DISPLAY
DESCRIPTION:This is an event reminder
TRIGGER:-P0DT0H30M0S
END:VALARM
END:VEVENT
END:VCALENDAR
";
			VCalendar calendar = new VCalendar(calString);
			var calEvent = calendar.GetCalendarComponents("VEVENT").First() as VEvent;
			var eventAlarms = calEvent.CalendarComponents["VALARM"];
			Assert.Equal((calEvent.GetComponentProperty("UID") as IValue<string>).Value, "0kusnhnnacaok1r02v16simh8c@google.com");
			Assert.Equal((calEvent.GetComponentProperty("DESCRIPTION") as IValue<string>).Value, "foo");
			Assert.Equal(2, eventAlarms.Count);

		}


		[Fact]
		public void ToStringTest()
		{
			var calString = @"BEGIN:VCALENDAR
PRODID:-//Google Inc//Google Calendar 70.9054//EN
VERSION:2.0
CALSCALE:GREGORIAN
X-WR-CALNAME:calmozilla1@gmail.com
X-WR-TIMEZONE:America/Los_Angeles
BEGIN:VTIMEZONE
TZID:America/Los_Angeles
X-LIC-LOCATION:America/Los_Angeles
BEGIN:DAYLIGHT
TZOFFSETFROM:-0800
TZOFFSETTO:-0700
TZNAME:PDT
DTSTART:19700308T020000
RRULE:FREQ=YEARLY;BYMONTH=3;BYDAY=2SU
END:DAYLIGHT
BEGIN:STANDARD
TZOFFSETFROM:-0700
TZOFFSETTO:-0800
TZNAME:PST
DTSTART:19701101T020000
RRULE:FREQ=YEARLY;BYMONTH=11;BYDAY=1SU
END:STANDARD
END:VTIMEZONE
BEGIN:VEVENT
DTSTART;TZID=America/Los_Angeles:20120629T130000
DTEND;TZID=America/Los_Angeles:20120629T140000
DTSTAMP:20120629T112428Z
UID:0kusnhnnacaok1r02v16simh8c@google.com
RRULE:FREQ=YEARLY;BYMONTH=11;BYDAY=1SU
CREATED:20120629T111935Z
DESCRIPTION:foo
LAST-MODIFIED:20120629T112428Z
LOCATION:Barcelona
SEQUENCE:0
STATUS:CONFIRMED
SUMMARY:Demo B2G Calendar
TRANSP:OPAQUE
BEGIN:VALARM
ACTION:EMAIL
DESCRIPTION:This is an event reminder
SUMMARY:Alarm notification
ATTENDEE:mailto:calmozilla1@gmail.com
TRIGGER:-P0DT0H30M0S
END:VALARM
BEGIN:VALARM
ACTION:DISPLAY
DESCRIPTION:This is an event reminder
TRIGGER:-P0DT0H30M0S
END:VALARM
END:VEVENT
END:VCALENDAR
";
			VCalendar calendar = new VCalendar(calString);
			var xmlDoc = @"<?xml version=""1.0"" encoding=""utf-8"" ?>
<C:calendar-query xmlns:D=""DAV:""
xmlns:C=""urn:ietf:params:xml:ns:caldav"">
<D:prop>
<D:getetag/>
<C:calendar-data>
<C:comp name=""VCALENDAR"">
<C:prop name=""VERSION""/>
<C:comp name=""VEVENT"">
<C:prop name=""SUMMARY""/>
<C:prop name=""UID""/>
<C:prop name=""DTSTART""/>
<C:prop name=""DTEND""/>
</C:comp>
<C:comp name=""VTIMEZONE""/>
</C:comp>
</C:calendar-data>
</D:prop>
<C:filter>
<C:comp-filter name=""VCALENDAR"">
<C:comp-filter name=""VEVENT"">
	<C:time-range start=""20060104T000000Z""
end=""20060105T000000Z""/>
</C:comp-filter>
</C:comp-filter>
</C:filter>
</C:calendar-query>";
			var xmlTree = XmlTreeStructure.Parse(xmlDoc);
			var node = xmlTree.GetChildAtAnyLevel("calendar-data");
			var newCalString = calendar.ToString(node);
			var newCal = new VCalendar(newCalString);

			Assert.Equal(2,newCal.CalendarComponents.Count);
			Assert.Contains("VEVENT",newCal.CalendarComponents.Keys);
			Assert.Contains("VTIMEZONE",newCal.CalendarComponents.Keys);
			Assert.Equal(4, newCal.CalendarComponents["VEVENT"].First().Properties.Count);


		}

	}
}
