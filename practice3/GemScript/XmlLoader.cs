using System;
using System.Xml.Serialization;

namespace GemScript;

public class XmlLoader
{

    [XmlRoot("SkladPotravin")]
    public class SkladRoot {

        [XmlElement("Zbozi")]
    public List<Potravina> potraviny = new List<Potravina>();
    }

    public static List<Potravina> NacistPotraviny(string path) {
        SkladRoot result;
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(SkladRoot));
        using(FileStream fileStream = new FileStream("data.xml", FileMode.Open)) {
                result = (SkladRoot)xmlSerializer.Deserialize(fileStream);
                return result?.potraviny ?? new List<Potravina>();
        }
    }
}
