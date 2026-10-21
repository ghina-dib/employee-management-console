using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement
{
    public class Manager : Employee
    {
        public decimal Bonus { get; }
        public Manager(int id, string name, string department, decimal salary, decimal bonus)
            : base(id, name, department, salary)

        {
            if (bonus < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(bonus), "Bonus must be greater than or equal to zero");
            }
            Bonus = bonus;
        }
        public override decimal CalculateAnnualPay()
        {
            return base.CalculateAnnualPay() + Bonus;
        }
        public override string ToString()
        {
            return "[Manager]" + base.ToString() + $" + Bonus: {Bonus:F2}";
        }
    }


}
