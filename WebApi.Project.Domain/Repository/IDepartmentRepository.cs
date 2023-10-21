using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Project.Domain.Entity;
using WebApi.Project.Domain.Repository.Base;

namespace WebApi.Project.Domain
{
    public interface IDepartmentRepository : IBaseReadOnlyRepository<Deparment, Guid>
    {
    }
}
