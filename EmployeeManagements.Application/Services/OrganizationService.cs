using EmployeeManagement.Api.Dtos.Organization;
using EmployeeManagement.Domain.Models;
using EmployeeManagements.Application.Interface;

namespace EmployeeManagement.Api.Service
{
    public class OrganizationService : IOrganizationService
    {
        private readonly IOrganizationRepository _repo;

        public OrganizationService(IOrganizationRepository repo) 
        {
            _repo = repo;
        }

        public async Task<IEnumerable<OrganizationResponse>> GetAllOrganizationsAsync()
        {
            var results = await _repo.GetAllOrganizationsAsync();
            return results.Select(ToResponse);
        }
        public async Task<OrganizationResponse?> GetOrganizationByIdAsync(int orgId) 
        {
            var org = await _repo.GetOrganizationByIdAsync(orgId);

            if (org == null) return null;

            return ToResponse(org);
        }
        
        public async Task<OrganizationResponse> CreateOrganizationAsync(CreateOrganizationRequest request) 
        {
            var entity = ToEntity(request);

            await _repo.CreateOrganizationAsync(entity);

            return ToResponse(entity);
        }

        public async Task<bool> UpdateOrganizationAsync(int orgId, UpdateOrganizationRequest request) 
        {
            var org = await _repo.GetOrganizationByIdAsync(orgId);

            if (org == null) return false;

            org.Name = request.name;
            org.ModifiedAt = DateTime.UtcNow;

            await _repo.UpdateOrganizationAsync(org);

            return true;
        }
        public async Task<bool> DeleteOrganizationAsync(int orgId) 
        {
            var org = await _repo.GetOrganizationByIdAsync(orgId);

            if (org == null) return false;

            await _repo.DeleteOrganizationAsync(org);
            return true;
        }

        private OrganizationResponse ToResponse(Organization request) 
        {
            return new OrganizationResponse(
                request.Id,
                request.Name,
                request.CreatedAt,
                request.ModifiedAt
                );
        }

        //Create
        private Organization ToEntity(CreateOrganizationRequest request) 
        {
            return new Organization
            {
                Name = request.name
            };
        }

        
    }
}
