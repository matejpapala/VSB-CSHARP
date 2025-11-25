using System;

namespace Kontakty;

public class NumberComparer : IComparer<int>
{
    public int Compare(int x, int y)
    {
        if(x == y) return 0;
        if(x % 2 == 0 && y % 2 == 1){
            return -1;
        }
        if(x % 2 == 1 && y % 2 == 0){
            return 1;
        }
        return x - y;
    }
}
