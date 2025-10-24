using System.Globalization;

namespace Calendar;

public static class TextParser
{
    public static List<Event> ParseText(string text)
    {
        var events = new List<Event>();
        var lines = LineSplitter(text);

        int i = 0;

        while (i < lines.Count)
        {
            while (i < lines.Count && string.IsNullOrWhiteSpace(lines[i]))
                i++;

            if (i >= lines.Count)
                break;

            var typeLine = lines[i++].Trim();
            var typeText = typeLine.TrimEnd(':').Trim().ToUpperInvariant();

            var name = lines[i++].Trim();
            var dateLine = lines[i++].Trim();
            var dateParts = dateLine.Split(';', StringSplitOptions.TrimEntries);

            DateTime start = DateTime.Parse(dateParts[0], CultureInfo.CurrentCulture);
            DateTime end   = DateTime.Parse(dateParts[1], CultureInfo.CurrentCulture);

            switch (typeText)
            {
                case "MEETING":
                {
                    var attendeesLine = lines[i++];
                    var attendees = ParseAttendees(attendeesLine);
                    events.Add(new Meeting(attendees, name, start, end));
                    break;
                }

                case "HOLIDAY":
                {

                    var locationLine = lines[i++].Trim();
                    var location = locationLine;
                    var attendeesLine = lines[i++];
                    var attendees = ParseAttendees(attendeesLine);

                    events.Add(new Holiday(name, start, end, location, attendees));
                    break;
                }

                case "APPOINTMENT":
                {
                    
                    events.Add(new Appointment(name, start, end));
                    break;
                }

                default:
                    break;
            }
        }

        return events;
    }

    private static List<string> LineSplitter(string text)
    {
        var result = new List<string>();
        using var reader = new StringReader(text);
        string? line;
        while ((line = reader.ReadLine()) != null)
        {
            result.Add(line);
        }
        return result;
    }

    private static Attendee[] ParseAttendees(string? line)
    {
        if (string.IsNullOrWhiteSpace(line))
            return Array.Empty<Attendee>();

        var parts = line.Split(';', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
        var list = new List<Attendee>(parts.Length);
        foreach (var p in parts)
        {
            list.Add(new Attendee(p));
        }

        return list.ToArray();
    }
}
