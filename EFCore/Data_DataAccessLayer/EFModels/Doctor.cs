using System;
using System.Collections.Generic;

namespace EFCore.Data_DataAccessLayer.EFModels;

public partial class Doctor
{
    public int DoctorId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Specialization { get; set; }

    public string? PhoneNumber { get; set; }

    public virtual ICollection<Patient> Patients { get; set; } = new List<Patient>();
}
