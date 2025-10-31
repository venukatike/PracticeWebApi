using System;
using System.Collections.Generic;

namespace HBP.api.Models;

public partial class FinancialCase
{
    public long CaseId { get; set; }

    public long PatientId { get; set; }

    public long? AssignedToUserId { get; set; }

    public DateTimeOffset OpenedOn { get; set; }

    public DateTimeOffset? ClosedOn { get; set; }

    public string Status { get; set; } = null!;

    public decimal EstimatedBalance { get; set; }

    public string? Notes { get; set; }

    public virtual AppUser? AssignedToUser { get; set; }

    public virtual ICollection<FinancialCaseNote> FinancialCaseNotes { get; set; } = new List<FinancialCaseNote>();

    public virtual Patient Patient { get; set; } = null!;
}
