using System;

namespace Calendar;

public class Appointment : Event
{
    public Appointment(string name, DateTime start, DateTime end) : base(name, start, end){

    }

    public override DateTime? GetReminderTime()
    {
        return Start.AddMinutes(-30);
    }
}
