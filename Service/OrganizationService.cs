using EmployeeManagement.Api.Data;
using EmployeeManagement.Api.Dtos.Organization;
using EmployeeManagement.Api.Model;
using EmployeeManagement.Api.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Api.Service
{
    internal class OrganizationService : IOrganizationService
    {
        private readonly EmployeeDbContext _dbContext;
        public OrganizationService(EmployeeDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<OrganizationResponse>> GetAllOrganizationsAsync()
        {
            return await _dbContext.Organizations
                            .AsNoTracking()
                            .OrderBy(o => o.Name)
                            .Select(o => new OrganizationResponse
                            (
                                o.Id,
                                o.Name
                            ))
                            .ToListAsync();
        }
        public async Task<OrganizationResponse?> GetOrganizationByIdAsync(int orgId) 
        {
            return await _dbContext.Organizations
                            .AsNoTracking()
                            .Where(o => o.Id == orgId)
                            .Select(o => new OrganizationResponse
                            (
                                o.Id,
                                o.Name

                            ))
                            .FirstOrDefaultAsync();
            
        }
        
        public async Task<OrganizationResponse> CreateOrganizationAsync(CreateOrganizationRequest request) 
        {
            var org = new Organization
            {
                Name = request.name,
                CreatedAt = DateTime.UtcNow
            };

            _dbContext.Organizations.Add(org);

            await _dbContext.SaveChangesAsync();

            return new OrganizationResponse(org.Id, org.Name);

        }

        public async Task<bool> UpdateOrganizationAsync(int orgId, UpdateOrganizationRequest request) 
        {
            var result = await _dbContext.Organizations.FindAsync(orgId);

            if (result == null) return false;

            result.Name = request.name;
            result.ModifiedAt = DateTime.UtcNow;

            await _dbContext.SaveChangesAsync();

            return true;
        }
        public async Task<bool> DeleteOrganizationAsync(int orgId) 
        {
            var result = await _dbContext.Organizations.FindAsync(orgId);

            if (result == null) return false;

            _dbContext.Organizations.Remove(result);

            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
