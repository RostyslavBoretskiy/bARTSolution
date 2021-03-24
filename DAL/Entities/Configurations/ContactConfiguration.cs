using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace bARTSolution.Domain.Data.Entities.Configurations
{
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.HasKey(c => c.ContactId);

            builder.HasIndex(c => c.Email).IsUnique();

            builder.HasOne(c => c.Account).WithMany(a => a.Contacts);
        }
    }
}
