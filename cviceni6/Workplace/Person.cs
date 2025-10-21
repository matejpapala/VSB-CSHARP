using System;

namespace Workplace;

internal class Person
{
    public readonly string Name;

    public int Age { get; set; }

    public Person(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }

    public virtual void PrintInfo() {
        Console.WriteLine($"{Name} : {Age}");
    }
}
