using System;
using System.Collections.Generic;

namespace HBP.api.Models;

public partial class Document
{
    public long DocumentId { get; set; }

    public string OwnerType { get; set; } = null!;

    public long OwnerId { get; set; }

    public string FileName { get; set; } = null!;

    public string? FileMimeType { get; set; }

    public long? FileSize { get; set; }

    public string? Url { get; set; }

    public long? UploadedByUserId { get; set; }

    public DateTimeOffset UploadedAt { get; set; }

    public string? Notes { get; set; }

    public virtual AppUser? UploadedByUser { get; set; }
}
