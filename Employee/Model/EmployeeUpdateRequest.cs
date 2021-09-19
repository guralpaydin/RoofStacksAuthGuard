namespace Employee.Model
{
    public class EmployeeUpdateRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Department { get; set; }
        public string Phone { get; set; }
    }
}
