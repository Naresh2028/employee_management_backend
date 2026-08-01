using EmployeeManagement.Api.Dtos.Organization;

namespace EmployeeManagements.Application.Interface
{
    public interface IOrganizationService
    {
        Task<IEnumerable<OrganizationResponse>> GetAllOrganizationsAsync();
        Task<OrganizationResponse?> GetOrganizationByIdAsync(int orgId);
        Task<OrganizationResponse> CreateOrganizationAsync(CreateOrganizationRequest request);
        Task<bool> UpdateOrganizationAsync(int OrgId,UpdateOrganizationRequest request);
        Task<bool> DeleteOrganizationAsync(int orgId);

    }
}
