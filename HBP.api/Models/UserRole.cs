using System;
using System.Collections.Generic;

namespace HBP.api.Models;

public partial class UserRole
{
    public long UserId { get; set; }

    public long RoleId { get; set; }

    public DateTime ModifiedDate { get; set; }

    public DateTime CreatedDate { get; set; }

    public bool DeletedFlag { get; set; }

    public virtual Role Role { get; set; } = null!;

    public virtual AppUser User { get; set; } = null!;
}
