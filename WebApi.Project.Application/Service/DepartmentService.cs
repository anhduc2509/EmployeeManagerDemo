using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Project.Domain.Entity;
using WebApi.Project.Domain.Repository.Base;

namespace WebApi.Project.Application.Service
{
    public class DepartmentService : BaseReadOnlyService<Deparment, DepartmentDto, Guid>, IDepartmentService
    {
        private readonly IMapper _mapper;
        
        public DepartmentService(IBaseReadOnlyRepository<Deparment, Guid> readOnlyRepository, IMapper mapper) : base(readOnlyRepository)
        {
            _mapper = mapper;
        }

        public override DepartmentDto MapEntityToEntityDto(Deparment entity)
        {
           var departmentDto = _mapper.Map<DepartmentDto>(entity);
            return departmentDto;
        }
    }
}
