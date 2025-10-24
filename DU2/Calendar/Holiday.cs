using System;

namespace Calendar;

public class Holiday : Event, IAttendees
{
    private string? _location;
    public string Location
    {
        get => _location ?? "Neznámé místo";
        set => _location = value;
    }
    private Attendee[] _attendees = Array.Empty<Attendee>();

    public Attendee[] Attendees
    {
        get => _attendees;
        set => _attendees = (value is null || value.Length == 0)
            ? Array.Empty<Attendee>()
            : value;
    }
    public Holiday(string name, DateTime start, DateTime end, string? location = null, Attendee[]? attendees = null) : base(name, start, end)
    {
        _location = string.IsNullOrWhiteSpace(location) ? null : location;
        _attendees = (attendees is { Length: > 0 })
            ? attendees
            : Array.Empty<Attendee>();
    }
    public override string ToString() => $"{base.ToString()} ({Location})";

    public override DateTime? GetReminderTime()
    {
        return null;
    }
}
