using System;
using System.Collections;
using System.Text.Json;
using System.Xml.Serialization;

namespace Practice;

public class Company : IEnumerable
{
    List<Employee> employees = new List<Employee>();

    public void Add(Employee emp) {
        employees.Add(emp);
        Console.WriteLine(emp.ToString());
    }

    public List<Employee> DeserializeFromJson(string path) {
        List<Employee> tempList = new List<Employee>();
        var options = new JsonSerializerOptions {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true,
        };
        string data = File.ReadAllText(path);
        tempList = JsonSerializer.Deserialize<List<Employee>>(data, options);
        return tempList;
    }

    public IEnumerator GetEnumerator()
    {
        foreach(Employee employee in employees) {
            foreach(PerformanceScores performanceScores in employee.PerformanceScores) {
                PerformanceScoreByMonth performanceScoreByMonth = new PerformanceScoreByMonth(employee.Name, performanceScores.Month, performanceScores.Score);
                yield return performanceScoreByMonth;
            }
        }
    }

    public void PrintStatistics() {

    }

    public IEnumerable<Employee> Sort(IComparer<Employee> comparer) {
        employees.Sort(comparer);
        return employees;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Save(string path) {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Employee>));
        using(FileStream fs = new FileStream(path, FileMode.Create)) {
            xmlSerializer.Serialize(fs, employees);
        }
    }
}
