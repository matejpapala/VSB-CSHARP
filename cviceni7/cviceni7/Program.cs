namespace cviceni7;

class Program
{
    static void Main(string[] args)
    {

        // int[] arr1 = [1,2,3,4];
        // string[] arr2 = ["A", "B", "C", "D"];
        // ArrayHelper<int>.Swap(arr1, 1, 2);
        // ArrayHelper<string>.Swap(arr2, 1, 2);
        // Console.WriteLine(string.Join(",", arr1));
        // Console.WriteLine(string.Join(",", arr2));

        // ArrayHelper2.Swap<int>(arr1, 1, 2);

        TreeMap<string, int> tree = new TreeMap<string, int>();

        tree["A"] = 11;
        tree["B"] = 21;
        tree["H"] = 15;
        tree["N"] = 31;

        try {

        Console.WriteLine(tree["A"]);
        Console.WriteLine(tree["B"]);
        } catch(KeyNotFoundException<string> e) {
            Console.WriteLine("Neobsahuje klic: " + e.Key);
        }
        catch(Exception e) {
            Console.WriteLine("Jina chyba: " + e.Message);
        }
    }
}
