using System;

namespace GemScript;

public class PriorityComparer : IComparer<SkladovaPolozka>
{
    public int Compare(SkladovaPolozka? x, SkladovaPolozka? y)
    {
        var XKrit = x.JeKriticka();
        var YKrit = y.JeKriticka();

        if(XKrit && !YKrit) {
            return -1;
        }else if(!XKrit && YKrit) {
            return 1;
        }
        if(x.Vaha > y.Vaha) {
            return -1;
        }else if(x.Vaha < y.Vaha) {
            return 1;
        }
        return string.Compare(x.Nazev, y.Nazev);
    }
}
