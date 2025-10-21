using System;

namespace Workplace;

internal class Manager : MonthlySalaryEmployee
{
    public Manager(string name, int age) : base(name, age, 80_000)
    {
        
    }

    public override double GetSalary()
    {
        return this.MonthlySalary + this.Age * 500 + GetBonus();
    }

    public override void PrintInfo()
    {
        Console.Write("Pozice: Manager ");
        base.PrintInfo();
    }
}
