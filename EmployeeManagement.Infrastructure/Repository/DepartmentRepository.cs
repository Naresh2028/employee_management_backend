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
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly EmployeeDbContext _dbContext; 
        public DepartmentRepository(EmployeeDbContext dbContext) 
        {
            _dbContext = dbContext;
        }
        public async Task  CreateAsync(Department rquest)
        {
            _dbContext.Departments.Add(rquest);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Department>> GetAllAsync(int orgId)
        {
            return await _dbContext.Departments
                    .Where(d => d.OrganizationId == orgId)
                    .ToListAsync();
        }

        public async Task<Department?> GetByIdAsync(int id)
        {
            return await _dbContext.Departments.FindAsync(id);
        }

        public async Task UpdateAsync(Department request)
        {
            _dbContext.Departments.Update(request);
            await _dbContext.SaveChangesAsync();
        }
    }
}
