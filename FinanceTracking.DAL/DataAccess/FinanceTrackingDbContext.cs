using FinanceTracking.DAL.Entities;
using FinanceTracking.DAL.Extensions;

using Microsoft.EntityFrameworkCore;

namespace FinanceTracking.DAL.DataAccess
{
    public sealed class FinanceTrackingDbContext : DbContext
    {
        public FinanceTrackingDbContext(DbContextOptions options) : base(options) { }

        public DbSet<AccountEntity> Accounts { get; set; }
        public DbSet<AccountTypeEntity> AccountTypes { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<MemberEntity> Members { get; set; }
        public DbSet<TransactionEntity> Transactions { get; set; }
        public DbSet<UserEntity> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.AddEntityConfigurations();
        }
    }
}
