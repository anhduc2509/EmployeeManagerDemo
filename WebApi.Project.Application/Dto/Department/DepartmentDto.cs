using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Project.Domain.Entity;

namespace WebApi.Project.Application
{
    public class DepartmentDto
    {
        public Guid DeparmentId { get; set; }

        public string DeparmentName { get; set; } = null!;

        public string? Description { get; set; }

        public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}
