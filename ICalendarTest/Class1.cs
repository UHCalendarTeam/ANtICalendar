﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using ICalendar;
using ICalendar.Calendar;

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
            var calendarString = calendar.ToString();
            Assert.Equal(calendarString.Length, calString.Length);
        }
        
    }
}
