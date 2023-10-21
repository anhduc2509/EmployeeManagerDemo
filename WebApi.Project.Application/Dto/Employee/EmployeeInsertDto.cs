using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Project.Domain.Entity;
using WebApi.Project.Domain;

namespace WebApi.Project.Application
{
    public class EmployeeInsertDto
    {

        public string EmployeeCode { get; set; } = null!;

        public string EmployeeName { get; set; } = null!;

        public Gender EmployeeGender { get; set; }

        public string? EmployeerPhone { get; set; }

        public string? EmployeeAddress { get; set; }

        public string EmployeePosition { get; set; } = null!;

        public Guid? DeparmentId { get; set; }

        public virtual DepartmentDto? Deparment { get; set; }
    }
}
