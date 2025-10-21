using System;

namespace Calendar;

public static class TextParser
{
    public static List<Event> ParseText(string text) {
        List<Event> events = new List<Event>();
        var lines = LineSplitter(text);
        int i = 0;
        while(i < lines.Count) {
            string line = lines[i].Trim();
            if(i < lines.Count && string.IsNullOrWhiteSpace(line)) {
                i++;
                continue;
            }
            if(line.StartsWith("APPOINTMENT")) {
                string name = lines[i + 1].Trim();
                DateTime start = lines[i + 2].Split(";")[0].ToDateTime();
            }
        }

        return events;
    }

    private static List<string> LineSplitter(string text) {
        var list = new List<string>();
        using var sr = new StringReader(text);
        string? line;
        while ((line = sr.ReadLine()) != null)
            list.Add(line);
        return list;
    }
}
