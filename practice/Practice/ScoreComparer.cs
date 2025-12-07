using System;

namespace Practice;

public class ScoreComparer : IComparer<Employee>
{
    public int Compare(Employee? x, Employee? y)
    {
        double xAvg = x.GetAvgScore();
        double yAvg = y.GetAvgScore();
        return xAvg.CompareTo(yAvg) * -1;
    }
}
