using System;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace Practice;

public class Employee
{
    [XmlAttribute("ID")]
    public string EmployeeId{get;set;}
    [JsonPropertyName("jmeno")]
    public string Name {get;set;}
    public string Department {get;set;}

    public List<PerformanceScores> PerformanceScores {get;set;}
    [XmlIgnore]
    public int Salary{get;set;}
    public string HireDate{get;set;}

    public override string ToString()
    {
        return $"{Name}";
    }

    public double GetAvgScore() {
        double totalScore = 0;
        foreach(var score in PerformanceScores) {
            totalScore += score.Score;
        }
        return totalScore/PerformanceScores.Count;
    }
}
