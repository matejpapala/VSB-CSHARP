using System;

namespace Calendar;

public class Calendar
{
    private List<Event> _events = new();
    public void Add(Event item) => _events.Add(item);

    public List<Event> this[int year, int month, int day]
    {
        get
        {
            var dayStart = new DateTime(year, month, day, 0, 0, 0);
            var dayEnd   = dayStart.AddDays(1);

            return _events
                .Where(e => e.Start < dayEnd && e.End > dayStart)
                .ToList();
        }
    }


    public List<Event> GetAllUpcomingEvents()
    {
        return _events
            .Where(e => e.isUpcoming)
            .ToList();
    }
}
