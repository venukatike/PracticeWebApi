using System;
using System.Collections.Generic;

namespace HBP.api.Models;

public partial class Appointment
{
    public long AppointmentId { get; set; }

    public long PatientId { get; set; }

    public long? ProviderId { get; set; }

    public DateTimeOffset ScheduledAt { get; set; }

    public int DurationMinutes { get; set; }

    public string Status { get; set; } = null!;

    public string? Reason { get; set; }

    public long? CreatedByUserId { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    public virtual AppUser? CreatedByUser { get; set; }

    public virtual Patient Patient { get; set; } = null!;

    public virtual Provider? Provider { get; set; }
}
