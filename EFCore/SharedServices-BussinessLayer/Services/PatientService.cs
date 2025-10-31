using EFCore.Data_DataAccessLayer.EFModels;
using EFCore.MyProjectInfrastructure.Interface;
using EFCore.SharedServices_BussinessLayer.Interfaces;

namespace EFCore.SharedServices_BussinessLayer.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepo patientRepo;
        public PatientService(IPatientRepo _patientRepo)
        {
            patientRepo = _patientRepo;
        }
        public  async Task<List<Patient>> GetAllPatients(int pageNumber, int pageSize)
        {
            return await patientRepo.GetAllPatients(pageNumber, pageSize);
        }
    }
}
