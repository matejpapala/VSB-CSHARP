using System;

namespace OpravnyTest;

public class Shop : Place
{
    public string Type{get;set;}
    public string? OpeningHours{get;set;}

    public Shop(string name, double lat, double lon, string type, string? openingHours) {
        Name = name;
        Lat = lat;
        Lon = lon;
        Type = type;
        OpeningHours = openingHours;
    }

    public override string ToString()
    {
        return $"OBCHOD | {Name} ({Lat}, {Lon}): {Type} - {OpeningHours}";
    }
}
