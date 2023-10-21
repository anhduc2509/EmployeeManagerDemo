using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Project.Domain
{
    public class EmployeeManager : IEmployeeManager
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeManager(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task CheckDuplicateCode(string code)
        {
            var  check = await _employeeRepository.FindByCodeAsync(code);
            if (check != null)
            {
                throw new ConflictException();
            }
        }

        public async Task CheckExitence(Guid id)
        {
            var check = await _employeeRepository.FindByIdAsync(id);
            if (check != null)
            {
                throw new ConflictException();
            }
        }
    }
}
