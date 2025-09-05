using System;
using System.Collections.Generic;

namespace HBP.api.Models;

public partial class AuthorizationRequest
{
    public long AuthorizationId { get; set; }

    public long PatientId { get; set; }

    public long? ProviderId { get; set; }

    public long? RequestorUserId { get; set; }

    public DateTimeOffset RequestedOn { get; set; }

    public string Status { get; set; } = null!;

    public string? ExternalAuthNumber { get; set; }

    public string? Notes { get; set; }

    public DateOnly? ValidFrom { get; set; }

    public DateOnly? ValidTo { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    public virtual ICollection<AuthorizationProcedure> AuthorizationProcedures { get; set; } = new List<AuthorizationProcedure>();

    public virtual Patient Patient { get; set; } = null!;

    public virtual Provider? Provider { get; set; }

    public virtual AppUser? RequestorUser { get; set; }
}
