using System;

namespace OpravnyTest;

public class Peak : Place
{
    public double? Elevation {get;set;}

    public Peak(string name, double lat, double lon, double? elevation) {
        Name = name;
        Lat = lat;
        Lon = lon;
        Elevation = elevation;
    }
    public override string ToString()
    {
        var vyska = Elevation.HasValue ? Elevation.Value.ToString() : "???";
        return $"VRCHOL | {Name} ({Lat}, {Lon}): {vyska}m.n.m.";
    }
}
