namespace EmployeeManagement.Api.Model
{
    public class Department
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string HrName { get; set; }
        public int OrganizationId { get; set; }
        public required Organization Organization { get; set; }
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
    }
}
