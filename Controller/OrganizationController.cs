using EmployeeManagement.Api.Dtos.Organization;
using EmployeeManagement.Api.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace EmployeeManagement.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    internal class OrganizationController : ControllerBase
    {
        private readonly IOrganizationService _organizationService;
        public OrganizationController(IOrganizationService organizationService) 
        {
            _organizationService = organizationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() 
        {
            var org = await _organizationService.GetAllOrganizationsAsync();

            return Ok(org);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id) 
        {
            var org = await _organizationService.GetOrganizationByIdAsync(id);

            if (org == null) return NotFound();

            return Ok(org);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateOrganizationRequest request) 
        {
            var created = await _organizationService.CreateOrganizationAsync(request);

            return CreatedAtAction(
                nameof(GetById), 
                new { created.Id},
                created);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateOrganizationRequest request) 
        {
            var updated = await _organizationService.UpdateOrganizationAsync(id, request);

            if (updated == false) return NotFound();

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id) 
        {
            var deleted = await _organizationService.DeleteOrganizationAsync(id);

            if (deleted == false) return NotFound();

            return NoContent();
        }
    }
}
