using EFCore.MyProject.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EFCore.MyProject.API.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatient _repository;

        public PatientController(IPatient repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var product = await _repository.GetByIdAsync(id);
            return product == null ? NotFound() : Ok(product);
        }
    }
}
