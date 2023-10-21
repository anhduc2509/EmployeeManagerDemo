using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Project.Domain;
using WebApi.Project.Domain.Repository.Base;

namespace WebApi.Project.Application
{
    public abstract class BaseCrudService<TEntity, TEntityDto, TEntityInsertDto, TEntityUpdateDto, TKey> : BaseReadOnlyService<TEntity, TEntityDto, TKey> ,ICrudService<TEntityDto, TEntityInsertDto, TEntityUpdateDto, TKey> where TEntityDto : class where TEntityInsertDto : class where TEntityUpdateDto : class where TEntity : IEntity<TKey> 
    {
        private readonly IBaseCrudRepository<TEntity, TKey> _baseCrudRepository;

        protected BaseCrudService(IBaseCrudRepository<TEntity, TKey> crudRepository) : base(crudRepository)
        {
            _baseCrudRepository = crudRepository;
        }

       



        public async Task<TEntityDto> CreateEntityAsync(TEntityInsertDto entity)
        {
            var entityInsert = await MapEntityInsertDtoToTEntity(entity);
            var result = await _baseCrudRepository.CreateAsync(entityInsert);
            var entityDto = MapEntityToEntityDto(result);
            return entityDto;
        }

        public async Task<int> DeleteEntityAsync(TKey id)
        {
            var entity = await _baseCrudRepository.GetByIdAsync(id);
            var result = await _baseCrudRepository.DeleteAsync(entity);
            return result;
        }

        public async Task<TEntityDto> UpdateEntityAsync(TKey id, TEntityUpdateDto entity)
        {
            var entityUpdate = await MapEntityUpdateDtoToTEntity(id, entity);
            var result = await _baseCrudRepository.UpdateAsync(entityUpdate);
            var entityDto = MapEntityToEntityDto(result);
            return entityDto;
        }

        public abstract Task<TEntity> MapEntityInsertDtoToTEntity(TEntityInsertDto entity);
        public abstract Task<TEntity> MapEntityUpdateDtoToTEntity(TKey id, TEntityUpdateDto entity);
    }
}
