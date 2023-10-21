using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Project.Domain
{
    public interface IDepartmentManager
    {
        public Task CheckExitence(Guid id);
    }
}
