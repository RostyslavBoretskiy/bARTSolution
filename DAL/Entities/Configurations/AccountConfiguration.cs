using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace bARTSolution.Domain.Data.Entities.Configurations
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(a => a.AccountId);
            builder.Property(i => i.AccountId).ValueGeneratedOnAdd();

            builder.HasIndex(a => a.Name).IsUnique();

            builder.HasMany(a => a.Contacts).WithOne(c => c.Account);
            builder.HasOne(a => a.Incident).WithMany(i => i.Accounts);
        }
    }
}
