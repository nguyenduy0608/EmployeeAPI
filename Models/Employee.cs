using System.ComponentModel.DataAnnotations;

namespace EmployeeAPI.Models
{
    public class Employee : BaseModel
    {
        [StringLength(255)]
        public string Code { get; set; }
        [StringLength(255)]
        public string Name { get; set; }
        [StringLength(20)]
        public string? Phone { get; set; }
        public DateTime? Dob { get; set; }
        [StringLength(255)]
        public string? Email { get; set; }
        [StringLength(255)]
        public string? Address { get; set; }
    }
}
