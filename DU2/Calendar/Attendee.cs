using System;

namespace Calendar;

public class Attendee
{
    public string Name{get; set;}

    public Attendee(string name)
    {
        Name = name;
    }
    public override string ToString()
    {
        return Name;
    }
}
