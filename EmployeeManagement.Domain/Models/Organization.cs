namespace EmployeeManagement.Domain.Models
{
    public class Organization
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public ICollection<Department> Departments { get; set; } = new List<Department>();
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
    }
}
