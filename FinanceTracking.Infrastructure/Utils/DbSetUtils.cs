using Microsoft.EntityFrameworkCore;

namespace FinanceTracking.Infrastructure.Utils
{
    public static class DbSetUtils
    {
        public static IQueryable<TEntity> AsNoTracking<TEntity>(this DbSet<TEntity> @this, bool noTracking) where TEntity : class
        {
            return @this == null ? throw new ArgumentNullException(nameof(@this)) : noTracking ? @this.AsNoTracking() : @this.AsQueryable();
        }
    }
}
