namespace HWFour;

class Program
{
    static void Main(string[] args)
    {
        ObservableList<Customer> list = new ObservableList<Customer>();
        /*
         Zde doplňte registraci událostí na přidání a odebrání položky seznamu (viz zadání).
        */
        // TODO: doplnit...
        list.OnAdd += (c) => Console.WriteLine("Přidáno: " + c.Name + " " + "(" + c.Age + ")");
        list.OnRemove += (c) => Console.WriteLine("Odebráno: " + c.Name + " " + "(" + c.Age + ")");


        LoadFromBin(list, args[0]);

        list.Remove(list[2]);

        string json = list.SerializeToJson();
        string xml = list.SerializeToXml();

        // Tento řádek je nutný kvůli správnému fungování v Kelvinu!
        xml = xml.Trim(new char[] { '\uFEFF', '\u200B' });

        SaveToTextFile(json, "customers.json");
        SaveToTextFile(xml, "customers.xml");

        Console.WriteLine(new string('\n', 5));

        Console.WriteLine(new string('=', 20));
        Console.WriteLine("JSON data");
        Console.WriteLine(new string('=', 20));
        Console.WriteLine();

        ObservableList<Customer> jsonCustomers = ObservableList<Customer>.DeserializeFromJson(
            LoadFromTextFile("customers.json")
            );
        Print(jsonCustomers);

        Console.WriteLine(new string('\n', 5));

        Console.WriteLine(new string('=', 20));
        Console.WriteLine("XML data");
        Console.WriteLine(new string('=', 20));
        Console.WriteLine();

        ObservableList<Customer> xmlCustomers = ObservableList<Customer>.DeserializeFromXml(
            LoadFromTextFile("customers.xml")
            );
        Print(xmlCustomers);
    }

    public static void LoadFromBin(ObservableList<Customer> list, string entryArg)
    {
        using (FileStream fileStream = new FileStream(entryArg, FileMode.Open))
        using (BinaryReader binaryReader = new BinaryReader(fileStream))
        {
            int count = binaryReader.ReadInt32();
            for (int i = 0; i < count; i++)
            {
                String name = binaryReader.ReadString();
                int age = binaryReader.ReadInt32();
                list.Add(new Customer { Name = name, Age = age });
            }
        }
    }

        private static void Print(ObservableList<Customer> customers)
    {
        Console.WriteLine("Zákazníci:");
        Console.WriteLine(new string('-', 15));
        foreach (Customer num in customers)
        {
            Console.WriteLine(num);
        }


        Console.WriteLine("\n");
        Console.WriteLine("Nezletilí zákazníci:");
        Console.WriteLine(new string('-', 15));
        foreach (Customer num in customers.Filter(
            c => c.Age < 18
            ))
        {
            Console.WriteLine(num);
        }


        Console.WriteLine("\n");
        Console.WriteLine("Zákazníci seřazení podle věku:");
        Console.WriteLine(new string('-', 15));
        foreach (Customer num in customers.OrderBy(new AgeComparer()))
        {
            Console.WriteLine(num);
        }
    }

    private static void SaveToTextFile(string content, string fileName) {
        File.WriteAllText(fileName, content);
    }

    private static string LoadFromTextFile(string fileName) {
        return File.ReadAllText(fileName);
    }
}
