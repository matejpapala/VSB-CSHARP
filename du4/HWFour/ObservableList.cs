using System;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Xml.Serialization;
using System.Collections;

namespace HWFour;

public class ObservableList<T> : IEnumerable<T>
{
    public List<T> values = new List<T>();
    public int Count => values.Count;

    public ObservableList() { }

    private ObservableList(IEnumerable<T> collection)
    {
        values = new List<T>(collection);
    }

    public event Action<T> OnAdd;
    public event Action<T> OnRemove;

    public IEnumerator<T> GetEnumerator()
    {
        int start = 0;
        int end = values.Count - 1;
        while(start <= end) {
            yield return values[start];
            if(start != end) {
                yield return values[end];
            }
            start++;
            end--;
        }
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
    public void Add(T item)
    {
        values?.Add(item);
        OnAdd?.Invoke(item);
    }

    public void Remove(T item)
    {
        values?.Remove(item);
        OnRemove?.Invoke(item);
    }



    public string SerializeToJson()
    {
        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            WriteIndented = true
        };
        return JsonSerializer.Serialize(values, options);
    }

    public static ObservableList<T> DeserializeFromJson(string json)
    {
        var options = new JsonSerializerOptions
        {
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            WriteIndented = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
        List<T> loadedItems = JsonSerializer.Deserialize<List<T>>(json, options);
        return new ObservableList<T>(loadedItems);
    }

    public string SerializeToXml()
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<T>));
        using (MemoryStream memoryStream = new MemoryStream())
        {
            xmlSerializer.Serialize(memoryStream, values);
            memoryStream.Seek(0, SeekOrigin.Begin);
            using StreamReader streamReader = new StreamReader(memoryStream);
            return streamReader.ReadToEnd();
        }
    }

    public static ObservableList<T> DeserializeFromXml(string xml)
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<T>));
        byte[] buffer = Encoding.UTF8.GetBytes(xml);
        using (MemoryStream memoryStream = new MemoryStream(buffer))
        {
            List<T> loadedItems = (List<T>)xmlSerializer.Deserialize(memoryStream);
            return new ObservableList<T>(loadedItems);
        }
    }

    public IEnumerable<T> Filter(Func<T, bool> predicate) {
        foreach(var item in values) {
            if(predicate(item)) {
                yield return item;
            }
        }
    }

    public IEnumerable<T> OrderBy(IComparer<T> comparer) {
        List<T> sortedList = new List<T>(values);
        sortedList.Sort(comparer);
        foreach(var item in sortedList){
            yield return item;
        }
    }


    public T this[int index] {
        get { return values[index];}
    }
}
