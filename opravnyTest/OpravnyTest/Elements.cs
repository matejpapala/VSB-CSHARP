using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace OpravnyTest;

public class Elements
{
    [JsonPropertyName("elements")]
    public List<Node> nodes {get;set;}

    public static Elements DeserializeFromJson(string path) {
        var options = new JsonSerializerOptions {
            WriteIndented = true,
        };
        var text = File.ReadAllText(path);
        return JsonSerializer.Deserialize<Elements>(text, options);
    }
}
