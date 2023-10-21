using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Project.Application
{
    public interface IReadOnlyService<TEntityDto, TKey> where TEntityDto : class
    {
        /// <summary>
        /// Ham lay tat ca phan tu
        /// </summary>
        /// <returns></returns>
        Task<List<TEntityDto>> GetAllEntityAsync();

        Task<TEntityDto> GetEntityByIdAsync(TKey id);
    }
}
