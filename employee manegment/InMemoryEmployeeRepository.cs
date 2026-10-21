using System;
using System.Collections.Generic;
using System.Text;

namespace employee_manegment
{
    public class InMemoryEmployeeRepository : IEmployeeRepository
    {
        private readonly List<Employee> employees = new List<Employee>();

        public void Add(Employee employee)
        {
            ArgumentNullException.ThrowIfNull(employee);
            if (employees.Any(e => e.Id == employee.Id))
            {
                throw new ArgumentException($"An employee with ID {employee.Id} already exists.", nameof(employee));
            }
            employees.Add(employee);
        }
        public Employee? GetById(int id)
        {
            return employees.FirstOrDefault(e => e.Id == id);
        }

        public List<Employee> GetByDepartment(string department)
        {
            if (string.IsNullOrWhiteSpace(department))
            {
                throw new ArgumentException("Department cannot be empty.", nameof(department));
            }
            return employees.Where(e => string.Equals(e.Department, department, StringComparison.OrdinalIgnoreCase)).ToList();

        }
        public bool Remove(int id)
        {
            var employee = GetById(id);
            if (employee == null)
            {
                return false;
            }
            return employees.Remove(employee);
        }
        public Employee? GetHighestPaid()
        {
            return employees.OrderByDescending(e => e.Salary).FirstOrDefault();
        }
        public IReadOnlyList<Employee> GetAll()
        {
            return employees.AsReadOnly();
        }
    }


}
