using System.Globalization;

namespace DU1;


public static class Funcs
{
    public static Employee[] ParseEmployeesCsv(string csv)
    {
        if (string.IsNullOrWhiteSpace(csv))
            return [];

        var lines = csv.Split(["\r\n", "\n", "\r"], StringSplitOptions.None);
        var employees = new List<Employee>();

        bool skipedFirstLine = false;
        foreach (var rawLine in lines)
        {
            var line = rawLine.Trim();
            if (string.IsNullOrEmpty(line))
                continue;

            if (!skipedFirstLine)
            {
                skipedFirstLine = true;
                continue;
            }

            var parts = line.Split(';');
            Array.Resize(ref parts, 5);
            for (int i = 0; i < parts.Length; i++)
                parts[i] = parts[i].Trim();

            var name = parts[0];
            var age = parts[1];
            var phone = parts[2];
            var salary = parts[3];
            var active = parts[4];

            int? ageValue = null;
            if (int.TryParse(age, NumberStyles.Integer, CultureInfo.InvariantCulture, out var ageParsed))
                ageValue = ageParsed;

            PhoneNumber? phoneNumberValue = null;
            if (!string.IsNullOrWhiteSpace(phone))
            {
                var parsedPhone = Funcs.ParsePhoneNumber(phone);
                if (parsedPhone != null)
                    phoneNumberValue = parsedPhone;
            }
            int salaryValue = Convert.ToInt32(salary);


            bool? isActiveValue = null;
            if (!string.IsNullOrWhiteSpace(active))
            {
                if (active.Equals("ano", StringComparison.OrdinalIgnoreCase))
                    isActiveValue = true;
                else if (active.Equals("ne", StringComparison.OrdinalIgnoreCase))
                    isActiveValue = false;
            }
            employees.Add(new Employee
            {
                Name = name,
                Age = ageValue,
                Phone = phoneNumberValue,
                Salary = salaryValue,
                IsActive = isActiveValue
            });

        }
        return employees.ToArray();
    }
    public static PhoneNumber? ParsePhoneNumber(string? raw)
    {
        if (string.IsNullOrWhiteSpace(raw))
            return null;

        var s = raw.Trim();

        foreach (char c in s)
            if (!(char.IsDigit(c) || c == '+'))
                return null;

        if (s.StartsWith("+"))
        {
            if (s.Length < 5)
                return null;

            var country = s.Substring(0, 4);
            var nationalStr = s.Substring(4);

            if (nationalStr.Length == 0)
                return null;

            if (long.TryParse(nationalStr, NumberStyles.Integer, CultureInfo.InvariantCulture, out var national))
                return new PhoneNumber(country, national);

            return null;
        }
        else
        {
            if (!long.TryParse(s, NumberStyles.Integer, CultureInfo.InvariantCulture, out var national))
                return null;

            return new PhoneNumber("+420", national);
        }
    }

    public static double? ComputeAverageAge(Employee[] employees, out int ignoredCount) {
        ignoredCount = 0;
        if ( employees == null || employees.Length == 0) {
            return 0;
        }
        int count = 0;
        double sum = 0;
        foreach(var employee in employees) {
            if(employee.Age.HasValue) {
                count++;
                sum += employee.Age.Value;
            }else {
                ignoredCount++;
            }
        }
        if(count == 0) return null;

        return sum / count;
    }
}
class Program
{
    public static void Main(string[] args)
    {
        if (args.Length == 0 || string.IsNullOrWhiteSpace(args[0]))
        {
            Console.WriteLine("Prosím, zadejte cestu k CSV souboru jako první argument.");
            return;
        }

        string csv;
        try
        {
            csv = File.ReadAllText(args[0]);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Chyba při čtení souboru: {ex.Message}");
            return;
        }

        var employees = Funcs.ParseEmployeesCsv(csv);

        var avg = Funcs.ComputeAverageAge(employees, out int ignored);
        Console.WriteLine($"Průměrný věk: {avg}");
        Console.WriteLine($"Počet zaměstnanců s neznámým věkem: {ignored}");

        var filtered = new List<Employee>();
        foreach (var e in employees)
        {
            if (e.IsActive == true && e.Salary > 30000 &&
                (e.Phone is null || e.Phone?.CountryCode != "+421"))
            {
                filtered.Add(e);
            }
        }

        if (filtered.Count == 0)
        {
            Console.WriteLine("Žádný zaměstnanec neodpovídá filtru.");
        }
        else
        {
            foreach (var e in filtered)
            {
                var phoneText = e.Phone?.PrintOut() ?? "";
                Console.WriteLine($"{e.Name} | {phoneText}");
            }
        }
    }
}
