using EFCore.MyProjectDomain.Entities;

namespace EFCore.MyProject.Application.Interfaces
{
    public interface IPatient
    {
        Task<Patient?> GetByIdAsync(int id);
        Task<IEnumerable<Patient>> GetAllAsync();

    }
}
