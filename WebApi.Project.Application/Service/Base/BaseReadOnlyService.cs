using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Project.Domain;
using WebApi.Project.Domain.Repository.Base;

namespace WebApi.Project.Application
{
    public abstract class BaseReadOnlyService<TEntity, TEntityDto, TKey> : IReadOnlyService<TEntityDto, TKey> where TEntityDto : class where TEntity : IEntity<TKey>
    {
        private readonly IBaseReadOnlyRepository<TEntity, TKey> _readOnlyRepository;

        public BaseReadOnlyService(IBaseReadOnlyRepository<TEntity, TKey> readOnlyRepository)
        {
            _readOnlyRepository = readOnlyRepository;
        }

        public async Task<List<TEntityDto>> GetAllEntityAsync()
        {
           var entities =  await _readOnlyRepository.GetAllAsync();
            var entitiesDto = entities.Select(entity => MapEntityToEntityDto(entity)).ToList();
            return entitiesDto;
        }

        public async Task<TEntityDto> GetEntityByIdAsync(TKey id)
        {
            var entity = await _readOnlyRepository.GetByIdAsync(id);
            var entityDto = MapEntityToEntityDto(entity);
            return entityDto;
        }

        public abstract TEntityDto MapEntityToEntityDto(TEntity entities);
    }
}
