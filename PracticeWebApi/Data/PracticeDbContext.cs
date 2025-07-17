using Microsoft.EntityFrameworkCore;
using PracticeWebApi.Model;

namespace PracticeWebApi.Data
{
    public class PracticeDbContext : DbContext
    {
        public PracticeDbContext(DbContextOptions<PracticeDbContext> optins) : base(optins)
        {
        }

        public DbSet<Employees> Employees { get; set; }

    }
}
