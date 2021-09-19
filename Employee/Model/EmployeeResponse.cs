using Employee.Entities;

namespace Employee.Model
{
    public class EmployeeResponse
    {
        public EmployeeEntity Employee { get; set; }

        public EmployeeResponse(EmployeeEntity employee)
        {
            Employee = employee;
        }
    }
}
