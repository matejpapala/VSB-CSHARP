using System;

namespace Workplace;

internal abstract class HourlySalaryEmployee : Employee
{
    public double HourlySalary{get; set;}
    public int HoursWorked{get; set;}
    public HourlySalaryEmployee(string name, int age, double hourlySalary) : base(name, age)
    {
        this.HourlySalary = hourlySalary;
    }
    public override double GetSalary() {
        return HourlySalary * HoursWorked + GetBonus();
    }
}
