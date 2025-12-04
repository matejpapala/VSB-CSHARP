using System;

namespace HWFour;

public class Customer
{
    public String Name {get;set;}
    public int Age {get;set;}

    public override string ToString()
    {
        return $"{Name} ({Age})";
    }
}
