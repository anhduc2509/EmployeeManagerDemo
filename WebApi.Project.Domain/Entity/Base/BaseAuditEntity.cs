using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Project.Domain
{
    public abstract class BaseAuditEntity
    {
        public DateTime? CreatedDate { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public string? ModifiedBy { get; set; }
    }
}
