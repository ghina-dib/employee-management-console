using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement
{
    public interface IEmployeeRepository
    {
        void Add(Employee employee);
        Employee? GetById(int id);
        List<Employee> GetByDepartment(string department);
        bool Remove(int id);
        Employee? GetHighestPaid();
        IReadOnlyList<Employee> GetAll();
         

    }
}
