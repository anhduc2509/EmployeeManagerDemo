using System;
using System.Collections.Generic;

namespace WebApi.Project.Domain.Entity;

public partial class Employee : BaseAuditEntity, IEntity<Guid>
{
    public Guid EmployeeId { get; set; }

    public string EmployeeCode { get; set; } = null!;

    public string EmployeeName { get; set; } = null!;

    public Gender EmployeeGender { get; set; }

    public string? EmployeerPhone { get; set; }

    public string? EmployeeAddress { get; set; }

    public string EmployeePosition { get; set; } = null!;

    public Guid? DeparmentId { get; set; }


    public virtual Deparment? Deparment { get; set; }

    public Guid GetId()
    {
        return EmployeeId;
    }

    public void SetId(Guid id)
    {
        EmployeeId = id;
    }
}
