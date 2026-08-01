namespace EmployeeManagement.Domain.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required decimal Salary { get; set; }
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
        public EmployeeProfile? EmployeeProfile { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
