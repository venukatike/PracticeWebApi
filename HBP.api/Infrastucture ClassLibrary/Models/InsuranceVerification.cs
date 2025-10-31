using System;
using System.Collections.Generic;

namespace HBP.api.Models;

public partial class InsuranceVerification
{
    public long VerificationId { get; set; }

    public long PatientInsuranceId { get; set; }

    public DateTimeOffset? VerifiedAt { get; set; }

    public long? VerifiedBy { get; set; }

    public string Status { get; set; } = null!;

    public string? Notes { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    public virtual PatientInsurance PatientInsurance { get; set; } = null!;

    public virtual AppUser? VerifiedByNavigation { get; set; }
}
