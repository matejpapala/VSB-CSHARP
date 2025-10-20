using System;

namespace Calendar;

public class Meeting : Event, IAttendees
{
    private Attendee[] attendees = Array.Empty<Attendee>();
    public Attendee[] Attendees{
        get => attendees ?? Array.Empty<Attendee>();
        set => attendees = (value is null || value.Length == 0)
            ? Array.Empty<Attendee>()
            : value;
    }

    public Meeting(Attendee[] attendees, string name, DateTime start, DateTime end) : base(name, start, end)
    {
        Attendees = attendees;
    }

    public override DateTime? GetReminderTime()
    {
        return (Start.AddMinutes(-30 + Attendees.Length * -10));
    }

}
