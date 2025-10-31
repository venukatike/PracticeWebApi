using System;
using System.Collections.Generic;

namespace HBP.api.Models;

public partial class AuditLog
{
    public long AuditId { get; set; }

    public string EventType { get; set; } = null!;

    public string? EntityType { get; set; }

    public string? EntityId { get; set; }

    public string? Detail { get; set; }

    public long? PerformedByUserId { get; set; }

    public DateTimeOffset PerformedAt { get; set; }

    public virtual AppUser? PerformedByUser { get; set; }
}
