using MapRendererLib;

namespace OSMMapLib;

public class Map
{
    public Layer Layer { get; set; }
    public double Lat { get; set; }
    public double Lon { get; set; }
    private int zoom;
    public int Zoom
    {
        get
        {
            int temp;
            if (zoom < 1)
            {
                temp = 1;
            }
            else if (zoom > Layer.MaxZoom)
            {
                temp = Layer.MaxZoom;
            }
            else
            {
                temp = zoom;
            }
            return temp;
        }
        set
        {
            zoom = value;
        }
    }
    public int CenterTileX
    {
        get
        {
            return (int)((Lon + 180.0) / 360.0 * (1 << Zoom));
        }
    }
    public int CenterTileY
    {
        get
        {
            return (int)((1.0 - Math.Log(Math.Tan(Lat * Math.PI / 180.0) + 1.0 / Math.Cos(Lat * Math.PI / 180.0)) / Math.PI) / 2.0 * (1 << Zoom));
        }
    }

    public void Render(string fileName)
    {
        MapRenderer mapRenderer = new MapRenderer(4, 4);
        for (int x = -2; x < 2; x++)
        {
            for (int y = -2; y < 2; y++)
            {
                Tile tile = this.Layer[this.CenterTileX + x, this.CenterTileY + y, this.Zoom];

                Console.WriteLine(tile);

                mapRenderer.Set(x + 2, y + 2, tile.Url);
            }
        }
        mapRenderer.Flush();
        mapRenderer.Render(fileName);
    }
}
