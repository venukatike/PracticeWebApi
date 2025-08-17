using EFCore.MyProject.Application.Interfaces;
using EFCore.MyProjectDomain.Entities;
using EFCore.MyProjectInfrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EFCore.MyProjectInfrastructure.Repositories
{
    public class PatientRepo : IPatient
    {
        private readonly MyDbContext _context;

        public PatientRepo(MyDbContext context)
        {
            _context = context;
        }

        public async Task<Patient> GetByIdAsync(int id)
        {
            return await _context.patient.FindAsync(id);
        }

        public async Task<IEnumerable<Patient>> GetAllAsync()
        {
            return await _context.patient.ToListAsync();
        }

    }
}
