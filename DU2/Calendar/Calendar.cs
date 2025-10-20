using System;

namespace Calendar;

public class Calendar
{
    private Event[] events = Array.Empty<Event>();
    void Add(EventTypeEnum eventType, string name, DateTime start, DateTime end, Attendee[]? attendees = null)
    {
        switch (eventType)
        {
            case EventTypeEnum.Appointment:
                events = events.Append(new Appointment(name, start, end)).ToArray();
                break;
            case EventTypeEnum.Holiday:
                events = events.Append(new Holiday(name, start, end)).ToArray();
                break;
            case EventTypeEnum.Meeting:
                events = events.Append(new Meeting(attendees ?? Array.Empty<Attendee>(), name, start, end)).ToArray();
                break;
        }
    }

    public Event[] this[int year, int month, int day]
    {
        get
        {
            var dayStart = new DateTime(year, month, day, 0, 0, 0);
            var dayEnd = dayStart.AddDays(1);

            return Array.FindAll(events, e => e.Start < dayEnd && e.End > dayStart);
        }
    }


    Event[] GetAllUpcomingEvents()
    {
        Event[] isUpcomingEvents = Array.Empty<Event>();
        foreach(var ev in events) {
            if(ev.isUpcoming) {
                isUpcomingEvents = isUpcomingEvents.Append(ev).ToArray();
            }
        }
        return isUpcomingEvents;
    }
}
