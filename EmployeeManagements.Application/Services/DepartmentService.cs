
using EmployeeManagement.Application.Dtos.Department;
using EmployeeManagements.Application.Interface;
using EmployeeManagement.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Api.Service
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _repo;

        public DepartmentService(IDepartmentRepository repo) 
        {
            _repo = repo;
        }
        public async Task<IEnumerable<DepartmentResponse>> GetAllDepartmentsAsync(int orgId)
        {
            var departments = await _repo.GetAllAsync(orgId);
            return departments.Select(ToResponse);
        }

        public async Task<DepartmentResponse?> GetByIdDepartmentAsync(int id)
        {
            var deparment = await _repo.GetByIdAsync(id);

            if (deparment == null) return null;

            return ToResponse(deparment);
        }

        public async Task<DepartmentResponse> CreateDepartmentAsync(CreateDepartmentRequest request)
        {
            var result = new Department
            {
                Name = request.Name,
                HeadOfDepartment = request.HeadOfDepartment,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                OrganizationId = request.OrgId
            };

            await _repo.CreateAsync(result);

            return ToResponse(result);
        }

        

        public async Task<bool> UpdateDepartmentAsync(int id, UpdateDepartmentRequest request)
        {
            var department = await _repo.GetByIdAsync(id);

            if (department == null) return false;

            department.Name = request.Name;
            department.HeadOfDepartment = request.HeadOfDepartment;
            department.ModifiedAt = DateTime.UtcNow;

            await _repo.UpdateAsync(department);

            return true;
        }

        public async Task<bool> UpdateDepartmentStatusAsync(int id,bool status)
        {
            var department = await _repo.GetByIdAsync(id);

            if (department == null) return false;

            department.IsActive = status;
            department.ModifiedAt = DateTime.UtcNow;

            await _repo.UpdateAsync(department);

            return true;
        }

        private DepartmentResponse ToResponse(Department request) 
        {
            return new DepartmentResponse(
                request.Id,
                request.Name,
                request.HeadOfDepartment,
                request.IsActive,
                request.OrganizationId
                );
        }

    }
}
