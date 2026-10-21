using System;
using System.Collections.Generic;
using System.Text;

namespace employee_manegment
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
