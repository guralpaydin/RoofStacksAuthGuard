using Employee.Entities;
using Employee.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee.Services
{
    public interface IEmployeeService
    {
        List<EmployeeEntity> GetEmployees();
        EmployeeResponse GetEmployee(int id);
        EmployeeResponse CreateEmployee(EmployeeRequest model);
        EmployeeResponse UpdateEmployee(int id ,EmployeeUpdateRequest model);

    }
}
