using System;
using System.Collections.Generic;

namespace HBP.api.Models;

public partial class AuthorizationProcedure
{
    public long AuthProcedureId { get; set; }

    public long AuthorizationId { get; set; }

    public string? ProcedureCode { get; set; }

    public string? Description { get; set; }

    public int Units { get; set; }

    public decimal? EstimatedCost { get; set; }

    public virtual AuthorizationRequest Authorization { get; set; } = null!;
}
