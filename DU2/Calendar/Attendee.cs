using System;

namespace Calendar;

public class Attendee
{
    string Name;

    Attendee(string name)
    {
        Name = name;
    }
    public override string ToString()
    {
        return Name;
    }
}
