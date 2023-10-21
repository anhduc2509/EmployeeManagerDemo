using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Project.Application.Dto;
using WebApi.Project.Domain;
using WebApi.Project.Domain.Entity;

namespace WebApi.Project.Application
{
    public class EmployeeService : BaseCrudService<Employee, EmployeeDto, EmployeeInsertDto, EmployeeUpdateDto, Guid>, IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IEmployeeManager _employeeManager;
        private readonly IDepartmentManager _departmentManager;
        private readonly IMapper _mapper;
        public EmployeeService(IEmployeeRepository employeeRepository ,IEmployeeManager employeeManager,IDepartmentManager departmentManager, IMapper mapper ) : base(employeeRepository)
        {
            _employeeRepository = employeeRepository;
            _employeeManager = employeeManager;
            _departmentManager = departmentManager;
            _mapper = mapper;
        }

        public async Task<FilterDto<EmployeeDto>> FilterEmployee(string expectedString, int currentPage, int pageSize)
        {
            var data = await _employeeRepository.FilterEmployee(expectedString, currentPage, pageSize);
            var employees = data.Select( e => MapEntityToEntityDto(e)).ToList();
            var total = await _employeeRepository.GetTotalFilterEmployee(expectedString);
            var filterDto = new FilterDto<EmployeeDto>();
            filterDto.TotalRecord = total;
            filterDto.Data = employees;
            return filterDto;
        }

        public override async Task<Employee> MapEntityInsertDtoToTEntity(EmployeeInsertDto entity)
        {
            await _employeeManager.CheckDuplicateCode(entity.EmployeeCode);
            
            var employee = _mapper.Map<Employee>(entity);
            employee.SetId(new Guid());
            return employee;
        }

        public override EmployeeDto MapEntityToEntityDto(Employee entity)
        {
            var employDto = _mapper.Map<EmployeeDto>(entity);

            return employDto;
        }

        public override async Task<Employee> MapEntityUpdateDtoToTEntity(Guid id, EmployeeUpdateDto entity)
        {
            await _employeeManager.CheckExitence(id);

            var employee = _mapper.Map<Employee>(entity);
            employee.SetId(new Guid());
            return employee;
        }
    }
}
