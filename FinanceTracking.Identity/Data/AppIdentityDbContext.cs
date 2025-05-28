using FinanceTracking.Identity.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracking.Identity.Data
{
    public sealed class AppIdentityDbContext : IdentityDbContext<User>
    {
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<User>(entity =>
            {
                entity.Property(e => e.Initials).HasMaxLength(10);
            });

            builder.HasDefaultSchema("fin-track.identity");
        }
    }
}