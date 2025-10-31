using System;
using System.Collections.Generic;

namespace HBP.api.Models;

public partial class Gfeitem
{
    public long GfeitemId { get; set; }

    public long Gfeid { get; set; }

    public string? ItemCode { get; set; }

    public string? Description { get; set; }

    public decimal EstimatedCost { get; set; }

    public int Quantity { get; set; }

    public virtual Gfe Gfe { get; set; } = null!;
}
