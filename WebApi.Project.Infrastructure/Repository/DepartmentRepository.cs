using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Project.Domain;
using WebApi.Project.Domain.Entity;

namespace WebApi.Project.Infrastructure
{
    public class DepartmentRepository : BaseReadOnlyRepository<Deparment, Guid>, IDepartmentRepository
    {
        public DepartmentRepository(EmployeedbContext dbContext) : base(dbContext)
        {
        }
    }
}
