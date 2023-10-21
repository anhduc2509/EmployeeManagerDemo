using Microsoft.AspNetCore.Mvc;
using WebApi.Project.Application;

namespace WebApi.Project.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DepartmentController : BaseReadOnlyController<DepartmentDto, Guid>
    {
        protected readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService) : base(departmentService)
        {
            _departmentService = departmentService;
        }
    }
}
