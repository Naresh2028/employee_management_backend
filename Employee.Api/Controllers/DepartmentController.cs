using EmployeeManagement.Application.Dtos.Department;
using EmployeeManagements.Application.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Api.Controller
{
    [Route("api/organizations/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        // Gets all departments.
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DepartmentResponse>>> GetAll(int orgId) 
        {
            var departments = await _departmentService.GetAllDepartmentsAsync(orgId);

            return Ok(departments);
        }

        // Get department using Id
        [HttpGet("{departmentId:int}")]
        public async Task<ActionResult<DepartmentResponse>> GetById(int departmentId) 
        {
            var department = await _departmentService.GetByIdDepartmentAsync(departmentId);

            if (department == null) return NotFound();

            return Ok(department);
        }

        // Create a new Department
        [HttpPost]
        public async Task<ActionResult<DepartmentResponse>> Create([FromBody] CreateDepartmentRequest request) 
        {
            var created = await _departmentService.CreateDepartmentAsync(request);

            return CreatedAtAction(nameof(GetById), new { id = created.Id, orgId = created.OrganizationId },created);
        }

        // Update an existing Department
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update(int id, [FromBody] UpdateDepartmentRequest request) 
        {
            var updated = await _departmentService.UpdateDepartmentAsync(id, request);

            if (updated == false) return NotFound();

            return NoContent();
        }

        // Update state changes
        [HttpPut("{id:int}/status")]
        public async Task<ActionResult> UpdateStatus(int id,bool status) 
        {
            var statusUpdated = await _departmentService.UpdateDepartmentStatusAsync(id, status);

            if (statusUpdated == false) return NotFound();

            return NoContent();
        }
    }
}
