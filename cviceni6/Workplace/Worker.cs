using System;

namespace Workplace;

internal class Worker : HourlySalaryEmployee
{
    public Worker(string name, int age) : base(name, age, 130)
    {
    }

    public override double GetBonus(){
        if(HoursWorked > 160) {
            return 5000;
        }else {
            return 0;
        }
    }
}
