namespace GemScript;

class Program
{
    static void Main(string[] args)
    {
        var json = JsonLoader.NacistPotraviny("data.json");
        var xml = XmlLoader.NacistPotraviny("data.xml");

        Sklad<SkladovaPolozka> sklad = new Sklad<SkladovaPolozka>();

        sklad.PridatZasoby(json);
        sklad.PridatZasoby(xml);
        Console.WriteLine($"Načteno elektro: {json.Count}");
        if (json.Count > 0) Console.WriteLine($"První elektro ks: {json[0].Mnozstvi}");

        foreach(SkladovaPolozka item in sklad) {
            Console.WriteLine(item.ToString());
        }

        sklad.Sort(new PriorityComparer());

        ReportGenerator.UlozitReport("report.txt", sklad);
    }
}
