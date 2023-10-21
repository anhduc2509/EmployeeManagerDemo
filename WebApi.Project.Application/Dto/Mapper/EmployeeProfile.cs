using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Project.Domain.Entity;

namespace WebApi.Project.Application.Dto.Mapper
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeDto>();

            CreateMap<EmployeeInsertDto, Employee>()
                .ForMember(e => e.CreatedBy, opt => opt.MapFrom(src => " "))
                .ForMember(e => e.CreatedDate, opt => opt.MapFrom(src => DateTime.Now));

            CreateMap<EmployeeUpdateDto, Employee>()
                .ForMember(e => e.ModifiedDate, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(e => e.ModifiedBy, opt => opt.MapFrom(src => DateTime.Now));
        }
    }
}
