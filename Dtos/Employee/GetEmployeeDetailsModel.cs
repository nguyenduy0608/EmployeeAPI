namespace EmployeeAPI.Dtos.Employee
{
    public class GetEmployeeDetailsModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string? Phone { get; set; }
        public DateTime? Dob { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
