using Microsoft.EntityFrameworkCore;
using WebApi.DotNetV8.Models;

namespace WebApi.DotNetV8.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // Fixed the CS0236 error by converting the field to a property with a getter
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>()
                .HasOne(p => p.Employee)
                .WithMany(e => e.Projects)
                .HasForeignKey(p => p.EmployeeId);
        }
    }
}
