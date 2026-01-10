using System;
using System.Xml.Linq;

namespace OpravnyTest;

public class PlacesComparer : IComparer<Place>
{
    public int Compare(Place? x, Place? y)
    {
        if(x is Peak && y is not Peak) {
            return -1;
        }
        if(x is not Peak && y is Peak) {
            return 1;
        }
        if(x is Peak && y is Peak) {
            Peak xPeak = (Peak)x;
            Peak yPeak = (Peak)y;

            double? xEle = xPeak.Elevation;
            double? yEle = yPeak.Elevation;

            if(xEle is null) {
                xEle = 0;
            }
            if(yEle is null) {
                yEle = 0;
            }
            if(xEle > yEle) {
                return -1;
            }else if(xEle < yEle) {
                return 1;
            }else {
                return x.Name.CompareTo(y.Name);
            }
        }
        return x.Name.CompareTo(y.Name);
    }
}
