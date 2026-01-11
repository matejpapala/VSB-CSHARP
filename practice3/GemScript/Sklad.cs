using System;
using System.Collections;

namespace GemScript;

public class Sklad<T> : IEnumerable<T> where T : SkladovaPolozka
{
    private List<T> zasoby = new List<T>();

    public void PridatZasoby(IEnumerable<T> polozky) {
        zasoby.AddRange(polozky);
    }

    public void Add(T item) {
        zasoby.Add(item);
    }

    public void Sort(IComparer<SkladovaPolozka> comparer) {
        zasoby.Sort(comparer);
    }

    public List<T> VyfiltrovatKriticke() {
        List<T> result = new List<T>();
        foreach(T item in zasoby) {
            if(item.JeKriticka()) {
                result.Add(item);
            }
        }
        return result;
    }
    public IEnumerator<T> GetEnumerator()
    {
        foreach(T item in zasoby) {
            if(item.Mnozstvi > 0) {
                yield return item;
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
