using System;
using System.Collections.Generic;
using System.Text;
using EmployeeManagement;

namespace EmployeeManagement
{
    public class Employee
    {
        public int Id { get; }
        public string Name { get; private set; }
        public string Department { get; private set; }
        public decimal Salary { get; private set; }

        public Employee(int id, string name, string department, decimal salary)
        {

            ValidateName(name);
            ValidateDepartment(department);

            if (salary <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(salary), "Salary must be greater than zero");
            }
            Id = id;
            Name = name;
            Department = department;
            Salary = salary;
        }
        private static void ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(
                    "Name cannot be empty.",
                    nameof(name));
            }
        }
        private static void ValidateDepartment(string department)
        {
            if (string.IsNullOrWhiteSpace(department))
            {
                throw new ArgumentException(
                    "Department cannot be empty.",
                    nameof(department));
            }
        }
        public void GiveRaise(decimal percentage)
        {
            if (percentage <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(percentage), "Percentage must be greater than zero");
            }
            Salary = Salary * (1 + percentage / 100m);
        }

        public virtual decimal CalculateAnnualPay()
        {
            decimal annualSalary = Salary * 12;
            return annualSalary;
        }
        public void Rename(string newName)
        {
            ValidateName(newName);
            Name = newName;
        }
        public void ChangeDepartment(string newDepartement)
        {
            ValidateDepartment(newDepartement);
            Department = newDepartement;
        }

        public override string ToString()
        {
            return $"#{Id} {Name} ({Department}) - {Salary:F2}";
        }

    }



}
