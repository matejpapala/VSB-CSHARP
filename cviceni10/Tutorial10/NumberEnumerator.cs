using System;
using System.Collections;
using System.Collections.Generic;

namespace Tutorial10;

public class NumberEnumerator : IEnumerator<int>
{
    public List<int> Data { get; set; }
    private int index = -1;
    public int Current { get { return Data[index]; } }

    object IEnumerator.Current => Current;

    public void Dispose()
    {
        
    }

    public bool MoveNext()
    {
        index++;
        return index < Data.Count;
    }

    public void Reset()
    {
        index = -1;
    }
}
