using System;

namespace Workplace;

internal class Secretary : MonthlySalaryEmployee
{
    public Secretary(string name, int age) : base(name, age, 20000)
    {
    }

    public override void PrintInfo()
    {
        Console.Write("Pozice: sekretářka ");
        base.PrintInfo();
    }
}
