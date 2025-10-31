using System.Linq;
using HBP.api.Data;
using HBP.api.DTO_s;
using HBP.api.Models;

public class PatientRepo : IPatient
{

    private readonly BillingDbContext _context;

    public PatientRepo(BillingDbContext context)
    {
        _context = context;
    }

    public List<PatientDTO> Get()
    {
        // Fix: Use Select instead of SelectMany and map Patient to PatientDTO
        return _context.Patients
            .Select(p => new PatientDTO
            {
                FirstName = p.FirstName,
                LastName = p.LastName,
                Dob = p.Dob,
                Gender = p.Gender
            })
            .ToList();
    }
}
