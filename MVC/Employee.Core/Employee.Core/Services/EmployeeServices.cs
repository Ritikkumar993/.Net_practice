using EmployeeApp.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeApp.Core.Services
{
    public sealed class EmployeeServices
    {
        private readonly IEmployeeRepository _repo;
        
        public EmployeeServices(IEmployeeRepository repo)
        {
            _repo = repo;
        }




    }
}
