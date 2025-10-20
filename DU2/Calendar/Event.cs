using System;

namespace Calendar;

public abstract class Event
{
    private DateTime _start;
    private DateTime _end;
    public DateTime Start {
        get => _start;
        set {
            if(value >= _end && _end != default) {
                _start = _end;
                _end = value;
            }else {
                _start = value;
            }
        }
    }
    public DateTime End{
        get => _end;
        set{
            if(value <= _start && _start != default) {
                _end = _start;
                _start = value;
            }else {
                _end = value;
            }
        }
    }
    public bool isUpcoming => Start > DateTime.SpecifyKind(new DateTime(2025, 10, 15, 15, 0 ,0), DateTimeKind.Local);
    string Name;
    

    public Event(string name, DateTime start, DateTime end)
    {
        Name = name;
        Start = start;
        End = end;

    }
    public abstract DateTime? GetReminderTime();

    public override string ToString() {
        return $"{Name}: {Start} - {End}";
    }
}
