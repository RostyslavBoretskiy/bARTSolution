using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace bARTSolution.Domain.Data.Entities.Configurations
{
    public class IncidentConfiguration : IEntityTypeConfiguration<Incident>
    {
        public void Configure(EntityTypeBuilder<Incident> builder)
        {
            builder.HasKey(i => i.Name);
            builder.Property(i => i.Name).ValueGeneratedOnAdd();

            builder.HasMany(a => a.Accounts).WithOne(a => a.Incident);
        }
    }
}
