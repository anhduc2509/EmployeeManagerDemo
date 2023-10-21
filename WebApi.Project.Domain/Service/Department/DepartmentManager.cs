using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Project.Domain
{
    public class DepartmentManager : IDepartmentManager
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentManager(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task CheckExitence(Guid id)
        {
            var check = await _departmentRepository.FindByIdAsync(id);
            if (check != null)
            {
                throw new ConflictException();
            }
        }
    }
}
