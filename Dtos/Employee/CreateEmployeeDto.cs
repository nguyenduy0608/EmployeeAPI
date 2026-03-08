using System.ComponentModel.DataAnnotations;

namespace EmployeeAPI.Dtos.Employee
{
    public class CreateEmployeeDto
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string? Phone { get; set; }
        public DateTime? Dob { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
    }
}
