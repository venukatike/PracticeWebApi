using EFCore.Data_DataAccessLayer.EFModels;

namespace EFCore.SharedServices_BussinessLayer.Interfaces
{
    public interface IPatientService
    {
        Task<List<Patient>> GetAllPatients(int pageNumber, int pageSize);
    }
}
