using EFCore.Data_DataAccessLayer.Data;
using EFCore.Data_DataAccessLayer.EFModels;
using EFCore.SharedServices_BussinessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCore.MyProject.API.Controllers
{
    [ApiController]
    [Route("api/")]
    public class PatientController : Controller
    {

        private readonly IPatientService patientService;
        private readonly MyDbContext context;
        public PatientController(IPatientService _patientService, MyDbContext _context)
        {
            patientService = _patientService;
            context = _context;
        }

        [HttpGet("{pageNumber}/{pageSize}")]
        public async Task<List<Patient>> GetAllPatients(int pageNumber, int pageSize)
        {
            return await patientService.GetAllPatients(pageNumber, pageSize);
        }


        [HttpGet()]
        public async Task<ActionResult<List<Employee>>> GetAllPatient()
        {
            //var second = await context.Employees.Select(e=>e.Salary).Distinct().OrderByDescending(e => e).Skip(id-1).FirstOrDefaultAsync();
            var gp = await context.Employees.GroupBy(e => e.EmployeeId).
                Select(e=> new {
                EmployeeId = e.Key,
                Salary = e.Count()
            }).ToListAsync();
            

            if (gp == null)
                return NotFound();

            return Ok(gp);
        }

    }
}
