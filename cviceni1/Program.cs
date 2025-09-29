namespace cviceni1;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Zadejte jmeno:");
        string? name = Console.ReadLine();

        if(string.IsNullOrWhiteSpace(name)) {
            Console.WriteLine("Jmeno nesmi byt prazdne");
            return;
        }

        string upperName = name.ToUpper();
        Console.WriteLine($"Ahoj {upperName}");
    }
}
