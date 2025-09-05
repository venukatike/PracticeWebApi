using System;
using System.Collections.Generic;

namespace HBP.api.Models;

public partial class PatientInsurance
{
    public long PatientInsuranceId { get; set; }

    public long PatientId { get; set; }

    public long InsuranceId { get; set; }

    public string? PolicyNumber { get; set; }

    public string? GroupNumber { get; set; }

    public DateOnly? EffectiveFrom { get; set; }

    public DateOnly? EffectiveTo { get; set; }

    public bool IsPrimary { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    public virtual Insurance Insurance { get; set; } = null!;

    public virtual ICollection<InsuranceVerification> InsuranceVerifications { get; set; } = new List<InsuranceVerification>();

    public virtual Patient Patient { get; set; } = null!;
}
