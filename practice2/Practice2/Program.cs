using System.Globalization;

namespace Practice2;

class Program
{
    static void Main(string[] args)
    {
        // NOTE: třídy / metody můžete pojmenovat i jinak než je v kódu níže.

        CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
        CultureInfo.CurrentUICulture = CultureInfo.InvariantCulture;

        Eshop eshop = new Eshop();

        // TODO: zde doplňte kód pro načtení dat

        List<Order> orders = eshop.DeserializeFromJson("data.json");

        // naplnění eshopu z načtených dat (orders jsou načtená data)
        foreach (Order order in orders)
        {
            eshop.Add(order);
        }

        Console.WriteLine("Počty objednaných kusů jednotlivých produktů:");
        Console.WriteLine("-------------------------------------------");

        // výpis statistik
        eshop.PrintStats();

        Console.WriteLine();

        // // seřazení objednávek
        eshop.Sort(new OrderComparer());

        Console.WriteLine("Zákazníci a počty produktů v jejich objednávkách:");
        Console.WriteLine("-------------------------------------------------");

        // // enumerování zákazníků a jimi zakoupených produktů
        foreach (OrderForEnumeration item in eshop)
        {
            Console.WriteLine(item.CustomerName + ": " + item.ItemName + " - " + item.TotalAmount);
        }

        eshop.SaveToBinary();
        eshop.SerializeToXml();
        eshop.SerializeToJson();
    }
}
