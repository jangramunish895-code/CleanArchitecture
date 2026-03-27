using Domain.Commons.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Commons;

public class BaseAuditableEntity : IBaseAuditableEntity
{
    public int Id { get; set ; }
    public DateTime? CreatedDate { get ; set ; } = DateTime.UtcNow;
    public DateTime? UpdatedDate { get ; set ; }
    public int? CreatedBy { get ; set ; }
    public int? UpdatedBy { get ; set ; }
    public bool IsDeleted { get; set; } = false;
    public bool IsActive { get; set; } = true;
}
