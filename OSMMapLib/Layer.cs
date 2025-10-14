using System;

namespace OSMMapLib;

public class Layer
{
    public string UrlTemplate { get; private set; }
    public int MaxZoom { get; private set; }

    public Layer(string urlTemplate = "https://{c}.tile.openstreetmap.org/{z}/{x}/{y}.png", int maxZoom = 10)
    {
        UrlTemplate = urlTemplate;
        MaxZoom = maxZoom;
    }

    public string FormatUrl(int x, int y, int zoom)
    {
        Random rndd = new Random();
        rndd.Next(0, 3);
        char c = (char)('a' + rndd.Next(0, 3));
        string tmp = UrlTemplate.Replace("{x}", x.ToString());
        tmp = tmp.Replace("{y}", y.ToString());
        tmp = tmp.Replace("{z}", zoom.ToString());
        tmp = tmp.Replace("{c}", c.ToString());
        return tmp;
    }

    public Tile this[int x, int y, int zoom]
    {
        get
        {
            return new Tile(x, y, zoom, FormatUrl(x, y, zoom));
        }
    }
}

