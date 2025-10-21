using System;

namespace Workplace;

internal class Population
{
    private int personCount = 0;
    private Person[] persons = new Person[100];

    public void Add(Person person)
    {
        if (personCount == persons.Length)
        {
            Array.Resize(ref persons, personCount + 10);
        }
        persons[personCount] = person;
        personCount++;
    }

    public void PrintUnemployed()
    {
        foreach (var person in persons)
        {
            if (person is Unemployed)
            {
                person.PrintInfo();
            }
        }
    }

    public void PrintEmployeesWithSalary()
    {
        foreach (var person in persons)
        {
            if (person is Employee employee)
            {
                person.PrintInfo();
                Console.WriteLine("Salary: " + employee.GetSalary());
            }
        }
    }

    public Employee GetPersonWithHighestSalary()
    {
        Employee highestSalary = null;
        foreach (var person in persons)
        {
            if (person is Employee employee)
            {
                if (highestSalary is null)
                {
                    highestSalary = employee;
                }
                else if (employee > highestSalary)
                {
                    highestSalary = employee;
                }
            }
        }
        return highestSalary;
    }

    public HourlySalaryEmployee[] GetHourlySalaryEmployees()
    {
        int count = 0;
        foreach (var person in persons)
        {
            if (person is HourlySalaryEmployee hourlySalaryEmployee)
            {
                count++;
            }
        }
        HourlySalaryEmployee[] hourlySalaryEmployees = new HourlySalaryEmployee[count];
        count = 0;
        foreach (var person in persons)
        {
            if (person is HourlySalaryEmployee hourlySalaryEmployee)
            {
                hourlySalaryEmployees[count++] = hourlySalaryEmployee;
            }
        }
        return hourlySalaryEmployees;
    }

    public void IncreaseHourlySalary(double increase, HourlySalaryEmployee[] employees)
    {
        foreach (var employee in employees)
        {
            employee.HourlySalary += increase;
        }
    }
}
