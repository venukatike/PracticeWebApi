using CodeFirst_V8.Data;
using CodeFirst_V8.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeFirst_V8.Controllers
{
    [ApiController]
    [Route("api/controller")]
    public class ConcurrencyController : Controller
    {
        private readonly AppDbContext context;

        public ConcurrencyController(AppDbContext appDbContext)
        {
            context = appDbContext;
        }

        [HttpPut("{id}")]
        public IActionResult PostPatientbyid(int id)
        {
            // Simulate two contexts (like two users)
            var options = context.Database.GetDbConnection().ConnectionString;
            var dbOptions = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlServer(options)
                .Options;

            using var contextA = new AppDbContext(dbOptions);
            using var contextB = new AppDbContext(dbOptions);

            // User A reads
            var patientA = contextA.patients.FirstOrDefault(p => p.Id == id);
            if (patientA == null) return NotFound("Patient not found");

            // User B reads
            var patientB = contextB.patients.FirstOrDefault(p => p.Id == id);

            // User A updates name
            patientA.Name = patientA.Name + " UpdatedByA";
            contextA.SaveChanges();

            // User B tries to update age
            patientB.Age += 1;
            try
            {
                contextB.SaveChanges();
                return Ok(new { message = "User B updated successfully (no conflict)." });
            }
            catch (DbUpdateConcurrencyException)
            {
                return Conflict(new { message = "User B failed: concurrency conflict detected!" });
            }
        
        }
    }
}
