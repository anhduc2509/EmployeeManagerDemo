using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Project.Domain
{
    public interface IEmployeeManager
    {
        /// <summary>
        /// Kiểm tra trùng mã
        /// </summary>
        /// <param name="code">mã</param>
        /// <returns>Nếu trùng mã return exception</returns>
        Task CheckDuplicateCode(string code);

        /// <summary>
        /// Kiểm tra đã tồn tại employee
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        Task CheckExitence(Guid id);
    }
}
