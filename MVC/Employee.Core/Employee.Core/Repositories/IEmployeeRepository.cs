using System;
using System.Collections.Generic;
using System.Text;
using EmployeeApp.Core.Models;


namespace EmployeeApp.Core.Repositories
{
    internal interface IEmployeeRepository
    {
        IEmployeeRepository? GetById(int id);

        IReadOnlyList<Employee> GetAll();
        void Add(Employee employee);
        void Update(Employee employee);
        void Delete(int id);
    }
}
