using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GemScript;

public class JsonLoader
{

    public class JsonRoot {
[JsonPropertyName("polozky")]
    public List<Elektronika> elektronika{get;set;} = new List<Elektronika>();
    }
    

    public static List<Elektronika> NacistPotraviny(string path) {
        string text = File.ReadAllText(path);
        var root = JsonSerializer.Deserialize<JsonRoot>(text);
        return root?.elektronika ?? new List<Elektronika>();
    }
}
