using HBP.api.Data;
using HBP.api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


[ApiController]
[Route("api/controller")]
public class PatientController : ControllerBase
{
    private readonly BillingDbContext _context;
    private readonly IPatientService pa;
    public PatientController(BillingDbContext context, IPatientService _pa)
    {
        _context = context;
        pa = _pa;
    }

    // GET: api/controller
    [HttpGet]
    public ActionResult<IEnumerable<AppUser>> Get()
    {
        return _context.AppUsers.ToList();
    }

    [HttpGet("AllP")]
    public dynamic GetAll()
    {
        return pa.Get();
    }

    // GET: api/controller/{id}
    [HttpGet("{id}")]
    public ActionResult<Patient> GetById(long id)
    {
        var patient = _context.Patients.Find(id);
        if (patient == null)
            return NotFound();
        return patient;
    }

    // POST: api/controller
    [HttpPost]
    public ActionResult<Patient> Create(Patient patient)
    {
        _context.Patients.Add(patient);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetById), new { id = patient.PatientId }, patient);
    }

    // PUT: api/controller/{id}
    [HttpPut("{id}")]
    public IActionResult Update(long id, Patient patient)
    {
        if (id != patient.PatientId)
            return BadRequest();

        _context.Entry(patient).State = EntityState.Modified;
        try
        {
            _context.SaveChanges();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Patients.Any(e => e.PatientId == id))
                return NotFound();
            throw;
        }
        return NoContent();
    }

    // DELETE: api/controller/{id}
    [HttpDelete("{id}")]
    public IActionResult Delete(long id)
    {
        var patient = _context.Patients.Find(id);
        if (patient == null)
            return NotFound();

        _context.Patients.Remove(patient);
        _context.SaveChanges();
        return NoContent();
    }
}
