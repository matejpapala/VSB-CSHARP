using System.Globalization;

namespace Practice;

class Program
{
    static void Main(string[] args)
    {
        // NOTE: třídy / metody můžete pojmenovat i jinak než je v kódu níže.

        CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
        CultureInfo.CurrentUICulture = CultureInfo.InvariantCulture;

        // TODO: zde doplňte kód pro načtení dat a naplnění knihovny.

        Company company = new Company();

        List<Employee> employees = company.DeserializeFromJson("employees.json");
        // nyplnění společnosti z načtených dat (employees jsou vámi načtená data)
        foreach (Employee employee in employees)
        {
            company.Add(employee);
        }



        Console.WriteLine("Průměrné skóre podle měsíců:");
        Console.WriteLine("----------------");
        // company.PrintAvegateScoreByMonthOfYear();

        Console.WriteLine();

        // seřazení zaměstnanců
        company.Sort(new ScoreComparer());

        // enumerování skóry zaměstnanců
        Console.WriteLine("Zaměstnanci a jejich skóre v jednotlivých měsících:");
        Console.WriteLine("----------------");
        foreach (PerformanceScoreByMonth score in company)
        {
            Console.WriteLine(score.Name + ": " + score.Month + " - " + score.Score);
        }

        // // serializace do XML
        company.Save("data.xml");
    }
}
