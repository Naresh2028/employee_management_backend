namespace EmployeeManagement.Application.Dtos.Department
{
    public record DepartmentResponse(int Id, string Name, string HeadOfDepartment, bool IsActive,int OrganizationId);
}
