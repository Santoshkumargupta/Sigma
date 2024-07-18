using Microsoft.EntityFrameworkCore;
using Sigma.Model;

namespace Sigma.Data
{
    public class SigmaDbContext:DbContext
    {
        public SigmaDbContext(DbContextOptions<SigmaDbContext> options)
        : base(options)
        {
        }

        public DbSet<Candidate> Candidates { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


        }

    }
}
