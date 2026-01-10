using System.Globalization;
using System.Runtime.CompilerServices;

namespace OpravnyTest;

class Program
{
    static void Main(string[] args)
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            string path = "data.json";


            var jsonData = Elements.DeserializeFromJson(path);

            Console.WriteLine($"Načteno z JSONu: {jsonData.nodes?.Count ?? 0} prvků.");

            Places places = new Places();
            foreach (var element in jsonData.nodes)
            {
                var place = element.ToPlace();
                if (place != null)
                {
                    places.Add(place);
                }
            }

            Console.WriteLine($"Počet míst v Places: {places.places.Count}");

            places.Sort();
            var peaks = places.Filter<Peak>();

            foreach (var peak in peaks)
            {
                Console.WriteLine(peak);
            }
            places.Save("places.txt");
    }
}
