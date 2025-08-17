using CodeFirst_V8.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeFirst_V8.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        DbSet<Patient> patients { get; set; }
        DbSet<CPT> refCPT { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Corrected the Ignore method usage to ignore the Patient entity type  
            modelBuilder.Ignore<Patient>();
        }
    }
}
