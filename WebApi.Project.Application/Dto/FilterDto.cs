using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Project.Application.Dto
{
    public class FilterDto<TEntities>
    {
        /// <summary>
        /// tong so ban ghi
        /// </summary>
        public int TotalRecord { get; set; }

        /// <summary>
        /// Tất cả record trong trang
        /// </summary>
        public List<TEntities> Data { get; set; }
    }
}
