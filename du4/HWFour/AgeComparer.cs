using System;

namespace HWFour;

public class AgeComparer : IComparer<Customer>
{
    public int Compare(Customer x, Customer y)
    {
        return x.Age.CompareTo(y.Age);
    }
}
