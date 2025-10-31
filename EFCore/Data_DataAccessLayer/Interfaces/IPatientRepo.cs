
using EFCore.Data_DataAccessLayer.EFModels;
using Microsoft.AspNetCore.Mvc;

namespace EFCore.MyProjectInfrastructure.Interface
{
    public interface IPatientRepo
    {
        Task<List<Patient>> GetAllPatients(int pageNumber, int pageSize);

        //IActionResult PostPatient(Patient patient);

    }
}
