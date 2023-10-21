using System;
using System.Collections.Generic;

namespace WebApi.Project.Domain.Entity;

public partial class Deparment : BaseAuditEntity, IEntity<Guid>
{
    public Guid DeparmentId { get; set; }

    public string DeparmentName { get; set; } = null!;

    public string? Description { get; set; }


    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public Guid GetId()
    {
        return DeparmentId;
    }

    public void SetId(Guid id)
    {
        DeparmentId = id;
    }
}
