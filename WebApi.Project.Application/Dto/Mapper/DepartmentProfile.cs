using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Project.Domain.Entity;

namespace WebApi.Project.Application.Dto.Mapper
{
    public class DepartmentProfile : Profile
    {
        protected DepartmentProfile()
        {
            CreateMap<Deparment, DepartmentDto>();
        }
    }
}
