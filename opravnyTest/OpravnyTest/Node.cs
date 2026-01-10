using System;
using System.Text.Json.Serialization;

namespace OpravnyTest;
public class Node
{
    public string Type {get;set;}
    public int Id {get;set;}
    [JsonPropertyName("lat")]
    public double Lat {get;set;}
    [JsonPropertyName("lon")]
    public double Lon {get;set;}
    [JsonPropertyName("tags")]
    public Dictionary<string, string> Tags{get;set;}

    public Place? ToPlace() {
        if(Tags.ContainsKey("natural")) {
            string name = Tags.ContainsKey("name") ? Tags["name"] : "Neznamy nazev";
            double ele = 0.0;
            if(Tags.ContainsKey("ele") && double.TryParse(Tags["ele"], out double eleParsed)) {
                ele = eleParsed;
            }
            return new Peak(name, Lat, Lon, ele);
        }else if(Tags.ContainsKey("shop")){
            string name = Tags.ContainsKey("name") ? Tags["name"] : "Neznamy nazev";
            string hours = Tags.ContainsKey("opening_hours") ? Tags["opening_hours"] : "";
            return new Shop(name, Lat, Lon, Tags["shop"], hours);
        }else {
            return null;
        }
    }
}
