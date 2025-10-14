using OSMMapLib;
namespace OSMMap;


class CycleLayer : Layer
{
    public CycleLayer() : base("https://b.tile-cyclosm.openstreetmap.fr/cyclosm/{z}/{x}/{y}.png", 17){

    }
}
class Program
{
    static void Main(string[] args)
    {
        Tile tile = new Tile(1, 2, 3, "https://a.tile.openstreetmap.org/3/1/2.png");
        Layer layer = new Layer();

        // Console.WriteLine(layer.FormatUrl(1,2,3));

        // Console.WriteLine(layer[1, 2, 3]);

        Map map = new Map();
        // map.Layer = new Layer(maxZoom: 20);
        map.Layer = new CycleLayer();
        map.Zoom = 17;
        map.Lat = 50.087451;
        map.Lon = 14.420671;
        map.Render("map.png");
    }
}
