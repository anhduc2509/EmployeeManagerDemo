using Microsoft.AspNetCore.Mvc;
using WebApi.Project.Application;

namespace WebApi.Project.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BaseReadOnlyController<TEntityDto, TKey> : ControllerBase where TEntityDto : class
    {
        protected readonly IReadOnlyService<TEntityDto, TKey> _readOnlyService;

        public BaseReadOnlyController(IReadOnlyService<TEntityDto, TKey> readOnlyService)
        {
            _readOnlyService = readOnlyService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _readOnlyService.GetAllEntityAsync();
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(TKey id)
        {
            var result = await _readOnlyService.GetEntityByIdAsync(id);
            return StatusCode(StatusCodes.Status200OK, result);

        }
    }
}
