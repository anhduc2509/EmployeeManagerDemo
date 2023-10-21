using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Project.Application
{
    public interface IDepartmentService : IReadOnlyService<DepartmentDto, Guid>
    {
    }
}
