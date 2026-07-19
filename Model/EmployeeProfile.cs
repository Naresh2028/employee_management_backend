namespace EmployeeManagement.Api.Model
{
    public class EmployeeProfile
    {
        public int Id { get; set; }
        public required string Address { get; set; }
        public required string PhoneNumber { get; set; }
        public DateTime JoinedDate { get; set; }
        public int EmployeeId { get; set; }
        public required Employee Employee { get; set; } 
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
