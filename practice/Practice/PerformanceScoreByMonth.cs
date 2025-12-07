using System;

namespace Practice;

public class PerformanceScoreByMonth
{
    public string Name {get;set;}
    public string Month{get;set;}
    public double Score {get;set;}

    public PerformanceScoreByMonth(string name, string month, double score) {
        Name = name;
        Month = month;
        Score = score;
    }
}
