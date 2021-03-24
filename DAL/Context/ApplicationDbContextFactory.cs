using Microsoft.EntityFrameworkCore;

namespace bARTSolution.Domain.Data.Context
{
    internal class ApplicationContextFactory : BaseContextFactory<ApplicationDbContext>
    {
        public ApplicationContextFactory() : base("DefaultConnection", typeof(ApplicationDbContext).Assembly.GetName().Name)
        { }
        protected override ApplicationDbContext CreateNewInstance(DbContextOptions<ApplicationDbContext> options)
        {
            return new ApplicationDbContext(options);
        }
    }
}
