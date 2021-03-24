using bARTSolution.Domain.Data.Entities;

using Microsoft.EntityFrameworkCore;

using System.Reflection;

namespace bARTSolution.Domain.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Incident> Incidents;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
