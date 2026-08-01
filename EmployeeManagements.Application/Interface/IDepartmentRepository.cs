using EmployeeManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagements.Application.Interface
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> GetAllAsync(int orgId);
        Task<Department?> GetByIdAsync(int id);
        Task CreateAsync(Department rquest);
        Task UpdateAsync(Department request);
    }
}
