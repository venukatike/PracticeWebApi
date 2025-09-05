using System;
using System.Collections.Generic;

namespace HBP.api.Models;

public partial class Patient
{
    public long PatientId { get; set; }

    public string? Mrn { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateOnly? Dob { get; set; }

    public string? Gender { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? Address { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual ICollection<AuthorizationRequest> AuthorizationRequests { get; set; } = new List<AuthorizationRequest>();

    public virtual ICollection<FinancialCase> FinancialCases { get; set; } = new List<FinancialCase>();

    public virtual ICollection<Gfe> Gves { get; set; } = new List<Gfe>();

    public virtual ICollection<PatientInsurance> PatientInsurances { get; set; } = new List<PatientInsurance>();
}
