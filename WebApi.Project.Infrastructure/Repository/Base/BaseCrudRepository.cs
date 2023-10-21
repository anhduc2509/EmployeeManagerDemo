using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Project.Domain;
using WebApi.Project.Domain.Entity;
using WebApi.Project.Domain.Repository.Base;

namespace WebApi.Project.Infrastructure.Repository.Base
{
    public abstract class BaseCrudRepository<TEntity, TKey> : BaseReadOnlyRepository<TEntity, TKey>, IBaseCrudRepository<TEntity, TKey> where TEntity : class, IEntity<TKey>
    {
        public BaseCrudRepository(EmployeedbContext dbContext) : base(dbContext)
        {
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
           var check =  await FindByIdAsync(entity.GetId());
            if (check != null)
            {
                throw new ConflictException();
            }
           await _dbSet.AddAsync(entity);
           await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<int> DeleteAsync(TEntity entity)
        {
            var check = await FindByIdAsync(entity.GetId());
            if (check == null)
            {
                throw new NotFoundException();
            }
            _dbSet.Remove(entity);
            var result =  await _dbContext.SaveChangesAsync();
            return result;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            var check = await FindByIdAsync(entity.GetId());
            if (check == null)
            {
                throw new NotFoundException();
            }
            _dbSet.Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
