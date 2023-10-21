using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Project.Domain.Entity;

namespace WebApi.Project.Domain
{
    public interface IEmployeeRepository : IBaseCrudRepository<Employee, Guid>
    {
        /// <summary>
        /// tim nhan vien theo code
        /// </summary>
        /// <param name="code"></param>
        /// <returns>Employee?</returns>
        Task<Employee?> FindByCodeAsync(string code);

        /// <summary>
        /// Hàm lọc nhân viên theo pageSize, currentPage, employeeName và employeeCode
        /// </summary>
        /// <param name="expectedString"></param>
        /// <param name="currentPage"></param>
        /// <param name="pageSize"></param>
        /// <returns>Employee</returns>
        Task<List<Employee>> FilterEmployee(string expectedString, int currentPage, int pageSize);

        /// <summary>
        /// Hàm lọc nhân viên theo employeeName và employeeCode
        /// </summary>
        /// <param name="expectedString"></param>
        /// <param name="currentPage"></param>
        /// <param name="pageSize"></param>
        /// <returns>Employee</returns>
        Task<List<Employee>> FilterEmployee(string expectedString);


        /// <summary>
        /// Hàm lấy tổng số bản ghi khi lọc
        /// </summary>
        /// <param name="expectedString"></param>
        /// <param name="currentPage"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<int> GetTotalFilterEmployee(string expectedString);
    }
}
