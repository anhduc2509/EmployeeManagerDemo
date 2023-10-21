using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Project.Application;
using WebApi.Project.Domain;

namespace WebApi.Project.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BaseCrudController<TEntity, TEntityDto, TEntityInsertDto, TEntityUpdateDto, TKey> : BaseReadOnlyController<TEntityDto, TKey> where TEntityDto : class where TEntityInsertDto : class where TEntityUpdateDto : class where TEntity : IEntity<TKey>
    {
        protected readonly ICrudService<TEntityDto, TEntityInsertDto, TEntityUpdateDto, TKey> _crudService;
        public BaseCrudController(ICrudService<TEntityDto, TEntityInsertDto, TEntityUpdateDto, TKey> crudService) : base(crudService)
        {
            _crudService = crudService;
        }

        public async Task<IActionResult> CreateEntityAsync([FromBody]TEntityInsertDto entity)
        {
            var result = await _crudService.CreateEntityAsync(entity);
            return StatusCode(StatusCodes.Status201Created, result);
        }

        public async Task<IActionResult> UpdateEntityAsync([FromRoute]TKey id, [FromBody]TEntityUpdateDto entity)
        {
            var result = await _crudService.UpdateEntityAsync(id, entity);
            return StatusCode(StatusCodes.Status200OK, result);
        }

        public async Task<IActionResult> DeleteEntityAsync([FromRoute] TKey id)
        {
            var result = await _crudService.DeleteEntityAsync(id);
            return StatusCode(StatusCodes.Status200OK, result);
        }
    }
}
