using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Project.Domain.Repository.Base;

namespace WebApi.Project.Domain
{
    public interface IBaseCrudRepository<TEntity, TKey> : IBaseReadOnlyRepository<TEntity, TKey> where TEntity : IEntity<TKey>
    {
        /// <summary>
        /// tao moi mot doi tuong
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Task<TEntity> CreateAsync(TEntity entity);

        /// <summary>
        /// Cap nhat thong tin doi tuong
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Task<TEntity> UpdateAsync(TEntity entity);

        /// <summary>
        /// Xoa doi tuong
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Task<int> DeleteAsync(TEntity entity);


    }
}
