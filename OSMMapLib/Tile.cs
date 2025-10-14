using System.Text;

namespace OSMMapLib;

public class Tile
{
    public int X { get; private set; }
    public int Y { get; private set; }
    private int zoom;
    public int Zoom { get 
    {return zoom;}
    private set{
        if(value < 1) {
            value = 1;
            zoom = value;
        }
    } }
    public string Url { get; private set;}

    public Tile(int x, int y,int zoom, string url) {
        X = x;
        Y = y;
        Zoom = zoom;
        Url = url;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("[").Append(X).Append(", ").Append(Y).Append(", ").Append(Zoom).Append("]: ").Append(Url);
        return sb.ToString();
    }
    
}
