using System;

namespace OpravnyTest;

public class Places
{
    public List<Place> places = new List<Place>();

    public void Add(Place place) {
        places.Add(place);
    }

    public void Sort() {
        places.Sort(new PlacesComparer());
    }

    public IEnumerable<T> Filter<T>() where T : Place {
        return places.OfType<T>();
    }

    public void Save(string path) {
        using (StreamWriter streamWriter = new StreamWriter(path)) {
            foreach(var place in places) {
                streamWriter.WriteLine(place.ToString());
            }
        }
    }
}
