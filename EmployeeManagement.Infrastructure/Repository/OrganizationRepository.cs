using EmployeeManagement.Domain.Models;
using EmployeeManagement.Infrastructure.Persistance.Data;
using EmployeeManagements.Application.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Infrastructure.Repository
{
    public class OrganizationRepository : IOrganizationRepository
    {
        private readonly EmployeeDbContext _dbContext;
        public OrganizationRepository(EmployeeDbContext dbContext) 
        {
            _dbContext = dbContext;
        }
        public async Task CreateOrganizationAsync(Organization request)
        {
            _dbContext.Add(request);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteOrganizationAsync(Organization organization)
        {
            _dbContext.Organizations.Remove(organization);
            await _dbContext.SaveChangesAsync();

        }

        public async Task<IEnumerable<Organization>> GetAllOrganizationsAsync()
        {
            return await _dbContext.Organizations.ToListAsync();
        }

        public async Task<Organization?> GetOrganizationByIdAsync(int orgId)
        {
            return await _dbContext.Organizations.FirstOrDefaultAsync(o => o.Id == orgId);
            
        }

        public async Task UpdateOrganizationAsync(Organization organization)
        {
            _dbContext.Organizations.Update(organization);
            await _dbContext.SaveChangesAsync();
        }
    }
}
