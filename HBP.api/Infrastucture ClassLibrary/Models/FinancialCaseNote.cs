using System;
using System.Collections.Generic;

namespace HBP.api.Models;

public partial class FinancialCaseNote
{
    public long CaseNoteId { get; set; }

    public long CaseId { get; set; }

    public long? CreatedByUserId { get; set; }

    public string NoteText { get; set; } = null!;

    public DateTimeOffset CreatedAt { get; set; }

    public virtual FinancialCase Case { get; set; } = null!;

    public virtual AppUser? CreatedByUser { get; set; }
}
