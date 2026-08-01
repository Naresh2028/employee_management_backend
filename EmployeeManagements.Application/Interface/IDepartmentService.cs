using EmployeeManagement.Application.Dtos.Department;

namespace EmployeeManagements.Application.Interface
{
    public interface IDepartmentService
    {
        Task<IEnumerable<DepartmentResponse>> GetAllDepartmentsAsync(   int id);
        Task<DepartmentResponse?> GetByIdDepartmentAsync(int id);
        Task<DepartmentResponse> CreateDepartmentAsync(CreateDepartmentRequest request);
        Task<bool> UpdateDepartmentAsync(int id, UpdateDepartmentRequest request);
        Task<bool> UpdateDepartmentStatusAsync(int id,bool status);
        
    }
}
