using System;

namespace Workplace;

internal abstract class MonthlySalaryEmployee : Employee
{
    public double MonthlySalary{ get; set; }
    public MonthlySalaryEmployee(string name, int age, double monthlySalary) : base(name, age)
    {
        this.MonthlySalary = monthlySalary;
    }
    public override double GetSalary() {
        return MonthlySalary + GetBonus();
    }
}
