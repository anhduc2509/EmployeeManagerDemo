using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Project.Domain.Entity;

namespace WebApi.Project.Domain
{
    public interface IUnitOfWork
    {
        IEmployeeRepository employeeRepository { get; }
        IDepartmentRepository departmentRepository { get; }
        void Commit();
        void Rollback();
        Task CommitAsync();
        Task RollbackAsync();
    }
}
