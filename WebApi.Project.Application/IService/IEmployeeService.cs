using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Project.Application.Dto;

namespace WebApi.Project.Application
{
    public interface IEmployeeService : ICrudService<EmployeeDto, EmployeeInsertDto, EmployeeUpdateDto, Guid>
    {
        /// <summary>
        /// loc nhan vien theo dieu kien su dung phan trang
        /// </summary>
        /// <param name="expectedString"></param>
        /// <param name="currentPage"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
       Task<FilterDto<EmployeeDto>> FilterEmployee(string expectedString, int currentPage, int pageSize);
        


    }
}
