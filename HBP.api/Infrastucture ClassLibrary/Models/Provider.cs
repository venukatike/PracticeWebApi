using System;
using System.Collections.Generic;

namespace HBP.api.Models;

public partial class Provider
{
    public long ProviderId { get; set; }

    public string Name { get; set; } = null!;

    public string? Npi { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? Address { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual ICollection<AuthorizationRequest> AuthorizationRequests { get; set; } = new List<AuthorizationRequest>();

    public virtual ICollection<Gfe> Gves { get; set; } = new List<Gfe>();
}
