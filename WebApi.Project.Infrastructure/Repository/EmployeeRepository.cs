using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Project.Domain;
using WebApi.Project.Domain.Entity;
using WebApi.Project.Infrastructure.Repository.Base;

namespace WebApi.Project.Infrastructure
{
    public class EmployeeRepository : BaseCrudRepository<Employee, Guid>, IEmployeeRepository
    {
        public EmployeeRepository(EmployeedbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Employee>> FilterEmployee(string expectedString, int currentPage, int pageSize)
        {
            var offset = (currentPage - 1) * pageSize;
            var limit = pageSize;

            var query = from e in _dbContext.Employees
                                   where e.EmployeeCode.Contains(expectedString) 
                                   || e.EmployeeName.Contains(expectedString)
                                   select e;
            var data = query.Skip(offset).Take(limit);
            return await data.ToListAsync();
        }

        public async Task<List<Employee>> FilterEmployee(string expectedString)
        {
            var query = from e in _dbContext.Employees
                        where e.EmployeeCode.Contains(expectedString)
                        || e.EmployeeName.Contains(expectedString)
                        select e;
            return await query.ToListAsync();
        }

        public async Task<Employee?> FindByCodeAsync(string code)
        {
            var result = await _dbSet.FirstOrDefaultAsync(e => e.EmployeeCode.Equals(code));
            return result;
        }


        public async Task<int> GetTotalFilterEmployee(string expectedString)
        {
            var query = from e in _dbContext.Employees
                        where e.EmployeeCode.Contains(expectedString)
                        || e.EmployeeName.Contains(expectedString)
                        select e;
            return await query.CountAsync();
        }
    }
}
