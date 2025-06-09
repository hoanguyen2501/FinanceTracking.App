using FinanceTracking.DAL.DataAccess;
using FinanceTracking.DAL.Primitives;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace FinanceTracking.API.Interceptor;

public sealed class AuditInterceptor : SaveChangesInterceptor
{
    public AuditInterceptor()
    {
    }

    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        if (eventData.Context is FinanceTrackingDbContext context)
        {
            context.ChangeTracker.Entries()
                .Where(e => e.Entity is IAuditEntity && (e.State == EntityState.Added || e.State == EntityState.Modified))
                .ToList()
                .ForEach(entry =>
                {
                    if (entry.Entity is IAuditEntity auditEntity)
                    {
                        if (entry.State == EntityState.Added)
                        {
                            auditEntity.CreatedAt = DateTime.UtcNow;
                        }

                        auditEntity.UpdatedAt = DateTime.UtcNow;
                    }
                });
        }
        return base.SavingChanges(eventData, result);
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
}
