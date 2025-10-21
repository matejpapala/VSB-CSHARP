using System;

namespace Workplace;

internal abstract class Employee : Person
{
    public Employee(string name, int age) : base(name, age)
    {
    }

    public abstract double GetSalary();

    public virtual double GetBonus()
    {
        return 0;
    }

    public static bool operator ==(Employee left, Employee right)
    {
        if (left is null && right is null)
        {
            return true;
        }
        if (left is null || right is null)
        {
            return false;
        }
        return left.GetSalary() == right.GetSalary();
    }

    public static bool operator !=(Employee left, Employee right)
    {
        return !(left == right);
    }

    public static bool operator >(Employee left, Employee right)
    {
        if (left is null || right is null)
        {
            return false;
        }
        return left.GetSalary() > right.GetSalary();
    }

    public static bool operator <(Employee left, Employee right)
    {
        if (left is null || right is null)
        {
            return false;
        }
        return left.GetSalary() < right.GetSalary();
    }
}
