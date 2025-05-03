using FinanceTracking.Domain.Entities;
using FinanceTracking.Domain.Extensions;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracking.Infrastructure.Data
{
    public sealed class FinanceTrackingDbContext(DbContextOptions<FinanceTrackingDbContext> options) : DbContext(options)
    {
        public DbSet<AccountEntity> Accounts { get; set; } = default!;
        public DbSet<AccountTypeEntity> AccountTypes { get; set; } = default!;
        public DbSet<CategoryEntity> Categories { get; set; } = default!;
        public DbSet<MemberEntity> Members { get; set; } = default!;
        public DbSet<TransactionEntity> Transactions { get; set; } = default!;
        public DbSet<UserEntity> Users { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.AddEntityConfigurations();
        }
    }
}
