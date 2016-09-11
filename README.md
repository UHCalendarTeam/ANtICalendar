# ICalendar
ANtICalendar is a library used to parse .ics file and create instances of its representation as .NET objects.

It started with our thesis project. We create a CalDAV server, a system to create, store and publish the events related to the University of Havana (ANtPlanner).

With the use of this library, is possible to create instances of VCalendar's object from .ics files (Parsing .ics files), following the specification given in the protocol RFC 5545. This VCalendar object, contains the Calendar Component objects and properties of the declared VCALENDAR in the iCalendar file. Each one of these Calendar Components, contain its Calendar Component's properties, as defined on the file.

Is possible to obtain the string representation of the VCalendar object, and even just take the string representation with some Calendar Components and properties.

We are working on some functionalities for the creation of Calendar Components and properties out of the box and pretty simple, among other extra funcionalities. 
