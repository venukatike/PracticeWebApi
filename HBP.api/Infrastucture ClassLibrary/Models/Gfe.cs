using System;
using System.Collections.Generic;

namespace HBP.api.Models;

public partial class Gfe
{
    public long Gfeid { get; set; }

    public long PatientId { get; set; }

    public long? ProviderId { get; set; }

    public long? CreatedByUserId { get; set; }

    public DateTimeOffset CreatedOn { get; set; }

    public decimal TotalEstimatedCost { get; set; }

    public string Status { get; set; } = null!;

    public string? Notes { get; set; }

    public virtual AppUser? CreatedByUser { get; set; }

    public virtual ICollection<Gfeitem> Gfeitems { get; set; } = new List<Gfeitem>();

    public virtual Patient Patient { get; set; } = null!;

    public virtual Provider? Provider { get; set; }
}
