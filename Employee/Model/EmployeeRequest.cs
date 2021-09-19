using System.ComponentModel.DataAnnotations;

namespace Employee.Model
{
    public class EmployeeRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Department { get; set; }
        [Required]
        public string Phone { get; set; }
    }
}