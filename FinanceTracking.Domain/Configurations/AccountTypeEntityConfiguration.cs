using FinanceTracking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceTracking.Domain.Configurations
{
    public sealed class AccountTypeEntityConfiguration : IEntityTypeConfiguration<AccountTypeEntity>
    {
        public void Configure(EntityTypeBuilder<AccountTypeEntity> builder)
        {
            builder.ToTable("AccountTypes");

            builder.HasMany(e => e.Accounts)
                .WithOne(e => e.AccountType)
                .HasForeignKey(e => e.AccountTypeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
