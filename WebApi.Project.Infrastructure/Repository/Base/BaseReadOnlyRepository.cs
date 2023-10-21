using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Project.Domain;
using WebApi.Project.Domain.Entity;
using WebApi.Project.Domain.Repository.Base;

namespace WebApi.Project.Infrastructure
{
    public abstract class BaseReadOnlyRepository<TEntity, TKey> : IBaseReadOnlyRepository<TEntity, TKey> where TEntity : class, IEntity<TKey>
    {
        protected readonly EmployeedbContext _dbContext;
        protected virtual DbSet<TEntity> _dbSet {  get; set; }


        protected BaseReadOnlyRepository(EmployeedbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }


        public async Task<TEntity?> FindByIdAsync(TKey id)
        {
            var result = await _dbSet.FindAsync(id);
            return result;
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(TKey id)
        {
            var result = await FindByIdAsync(id); 
            if(result == null)
            {
                throw new NotFoundException();
            }
            return result;
        }
    }
}
