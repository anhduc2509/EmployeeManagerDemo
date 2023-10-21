using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Project.Application
{
    public interface ICrudService<TEntityDto, TEntityInsertDto, TEntityUpdateDto, TKey> : IReadOnlyService<TEntityDto, TKey> where TEntityDto : class where TEntityInsertDto : class where TEntityUpdateDto : class
    {
        /// <summary>
        /// tao moi mot doi tuong
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<TEntityDto> CreateEntityAsync(TEntityInsertDto entity);

        /// <summary>
        /// cap nhat mot doi tuong
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<TEntityDto> UpdateEntityAsync(TKey id, TEntityUpdateDto entity);

        /// <summary>
        /// xoa mot doi tuong
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<int> DeleteEntityAsync(TKey id);
    }
}
