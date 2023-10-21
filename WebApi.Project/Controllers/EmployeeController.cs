using Microsoft.AspNetCore.Mvc;
using WebApi.Project.Application;
using WebApi.Project.Domain.Entity;

namespace WebApi.Project.Controllers
{
    public class EmployeeController : BaseCrudController<Employee, EmployeeDto, EmployeeInsertDto, EmployeeUpdateDto, Guid>
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService) : base(employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> filterEmployee([FromBody] string expectedString, [FromBody] int currentPage, [FromBody] int pageSize)
        {
            var result = await _employeeService.FilterEmployee(expectedString, currentPage, pageSize);
            return Ok(result);
        }
    }
}
