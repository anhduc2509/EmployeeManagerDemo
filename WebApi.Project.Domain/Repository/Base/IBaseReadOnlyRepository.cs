using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Project.Domain.Repository.Base
{
    public interface IBaseReadOnlyRepository<TEntity, TKey> where TEntity : IEntity<TKey> 
    {
        /// <summary>
        /// Lay ra tat ca doi tuong
        /// </summary>
        /// <returns></returns>
        public Task<List<TEntity>> GetAllAsync();
        /// <summary>
        /// Lay doi tuong theo khoa
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Task<TEntity> GetByIdAsync(TKey id);

        /// <summary>
        /// Lay doi tuong theo khoa
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Task<TEntity?> FindByIdAsync(TKey id);


    }
}
