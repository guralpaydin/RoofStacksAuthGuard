using Employee.Entities;
using Employee.Helpers;
using Employee.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Employee.Services
{
    public class EmployeeService : IEmployeeService
    {
        private DataContext context;
        public EmployeeService(
                    DataContext context)
        {
            this.context = context;
        }
        public EmployeeResponse CreateEmployee(EmployeeRequest model)
        {
            int id = context.Employees.Count();
            EmployeeEntity employeeEntity = new EmployeeEntity
            {
                Id = id + 1,
                Name = model.Name,
                LastName = model.LastName,
                Address = model.Address,
                Department = model.Department,
                Phone = model.Phone
            };
            context.Employees.Add(employeeEntity);
            context.SaveChanges();

            return new EmployeeResponse(employeeEntity);
        }

        public EmployeeResponse GetEmployee(int id)
        {
            var employee = context.Employees.SingleOrDefault(x => x.Id == id);
            if (employee == null) return null;

            return new EmployeeResponse(employee);
        }

        public List<EmployeeEntity> GetEmployees()
        {
            if (context.Employees == null) return null;

            List<EmployeeResponse> employeeResponses = new List<EmployeeResponse>();

            foreach (var item in context.Employees)
            {
                employeeResponses.Add(new EmployeeResponse(item));
            }

            return new List<EmployeeEntity>(context.Employees);
        }

        public EmployeeResponse UpdateEmployee(int id ,EmployeeUpdateRequest model)
        {
            var employee = context.Employees.SingleOrDefault(x => x.Id == id);
            if (employee == null) return null;

            employee.Name = (model.Name != null) ? model.Name : employee.Name;
            employee.LastName = (model.LastName != null) ? model.LastName : employee.LastName;
            employee.Address = (model.Address != null) ? model.Address : employee.Address;
            employee.Department = (model.Department != null) ? model.Department : employee.Department;
            employee.Phone = (model.Phone != null) ? model.Phone : employee.Phone;
            context.SaveChanges();

            return new EmployeeResponse(employee);
        }
    }
}
