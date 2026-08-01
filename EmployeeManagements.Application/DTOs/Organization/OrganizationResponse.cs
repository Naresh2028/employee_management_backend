namespace EmployeeManagement.Api.Dtos.Organization
{
    public record OrganizationResponse(int Id, string Name, DateTime CreatedAt, DateTime? ModifiedAt);
}
