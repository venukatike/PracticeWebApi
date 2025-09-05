using System;
using System.Collections.Generic;

namespace HBP.api.Models;

public partial class Insurance
{
    public long InsuranceId { get; set; }

    public string PayerName { get; set; } = null!;

    public string? PayerCode { get; set; }

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    public virtual ICollection<PatientInsurance> PatientInsurances { get; set; } = new List<PatientInsurance>();
}
