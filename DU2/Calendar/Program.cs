using System.Globalization;
namespace Calendar;

class Program
{
    static void Main(string[] args)
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("cs-CZ");
        string txt = File.ReadAllText(args[0]);

    }
}
