using System;
using System.Collections.Generic;

namespace EFCore.MyProjectDomain.Entities;

public partial class Patient
{
    public int? Id { get; set; }

    public string? Name { get; set; }

    public int? Age { get; set; }

    public int? Col { get; set; }

    public int? Coolie { get; set; }

    public int? Coolie2 { get; set; }
}
