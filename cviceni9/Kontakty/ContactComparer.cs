using System;

namespace Kontakty;

public class ContactComparer : IComparer<Contact>
{
    public int Compare(Contact? x, Contact? y)
    {
        return x.Name.CompareTo(y.Name);
    }
}
