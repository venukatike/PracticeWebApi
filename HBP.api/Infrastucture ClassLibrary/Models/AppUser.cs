using System;
using System.Collections.Generic;

namespace HBP.api.Models;

public partial class AppUser
{
    public long UserId { get; set; }

    public string Username { get; set; } = null!;

    public string? Email { get; set; }

    public string? DisplayName { get; set; }

    public string? PasswordHash { get; set; }

    public bool IsActive { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual ICollection<AuditLog> AuditLogs { get; set; } = new List<AuditLog>();

    public virtual ICollection<AuthorizationRequest> AuthorizationRequests { get; set; } = new List<AuthorizationRequest>();

    public virtual ICollection<Document> Documents { get; set; } = new List<Document>();

    public virtual ICollection<FinancialCaseNote> FinancialCaseNotes { get; set; } = new List<FinancialCaseNote>();

    public virtual ICollection<FinancialCase> FinancialCases { get; set; } = new List<FinancialCase>();

    public virtual ICollection<Gfe> Gves { get; set; } = new List<Gfe>();

    public virtual ICollection<InsuranceVerification> InsuranceVerifications { get; set; } = new List<InsuranceVerification>();

    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}
