using System;
using System.Collections.Generic;

namespace HBP.api.Models;

public partial class VwPatientSummary
{
    public long PatientId { get; set; }

    public string? Mrn { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateOnly? Dob { get; set; }

    public string? Phone { get; set; }

    public int? AppointmentCount { get; set; }

    public decimal? OpenBalances { get; set; }
}
