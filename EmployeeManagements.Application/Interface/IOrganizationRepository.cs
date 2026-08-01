using EmployeeManagement.Api.Dtos.Organization;
using EmployeeManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagements.Application.Interface
{
    public interface IOrganizationRepository
    {
        Task<IEnumerable<Organization>> GetAllOrganizationsAsync();
        Task<Organization?> GetOrganizationByIdAsync(int orgId);
        Task CreateOrganizationAsync(Organization request);
        Task UpdateOrganizationAsync(Organization organization);
        Task DeleteOrganizationAsync(Organization organization);
    }
}
