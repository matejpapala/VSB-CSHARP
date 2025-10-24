using System.Globalization;
namespace Calendar;

class Program
{
    static void Main(string[] args)
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("cs-CZ");
        string txt = File.ReadAllText(args[0]);
        Calendar calendar = new Calendar();
        var events = TextParser.ParseText(txt);
        foreach(Event singleEvent in events) {
            calendar.Add(singleEvent);
        }
        var today = new DateTime(2025, 10, 15);

        var todaysEvents = calendar[today.Year, today.Month, today.Day];

        Console.WriteLine("DNEŠNÍ UDÁLOSTI:");
        Console.WriteLine("----------");
        foreach (var ev in todaysEvents)
        {
            Console.WriteLine(ev.ToString());
        }
        Console.WriteLine();

        Console.WriteLine("LIDÉ SE KTERÝMI SE DNES UVIDÍM:");
        Console.WriteLine("----------");
        foreach (var ev in todaysEvents)
        {
            if (ev is IAttendees withAttendees)
            {
                foreach (var person in withAttendees.Attendees)
                {
                    Console.WriteLine($"{person.Name} - {ev.Start}");
                }
            }
        }
        Console.WriteLine(); 

        Console.WriteLine("ČASY PŘIPOMENUTÍ DNEŠNÍCH UDÁLOSTÍ:");
        Console.WriteLine("----------");

        foreach (var ev in todaysEvents)
        {
            DateTime? reminder = ev.GetReminderTime();
            if (reminder.HasValue)
            {
                Console.WriteLine($"{ev.ToString()} => {reminder.Value}");
            }
            else
            {
                Console.WriteLine($"{ev.ToString()} => ");
            }
        }
        Console.WriteLine();

        var upcoming = calendar.GetAllUpcomingEvents();

        Console.WriteLine("BUDOUCÍ UDÁLOSTI:");
        Console.WriteLine("----------");
        foreach (var ev in upcoming)
        {
            Console.WriteLine(ev.ToString());
        }

    }
}
