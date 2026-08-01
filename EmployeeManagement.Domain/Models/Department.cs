namespace EmployeeManagement.Domain.Models
{
    public class Department
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string HeadOfDepartment { get; set; }
        public int OrganizationId { get; set; }
        public Organization? Organization { get; set; }
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public bool IsActive { get; set; } = true;

    }
}
