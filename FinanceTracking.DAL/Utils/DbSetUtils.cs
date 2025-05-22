using Microsoft.EntityFrameworkCore;

namespace FinanceTracking.DAL.Utils
{
    public static class DbSetUtils
    {
        public static IQueryable<TEntity> AsNoTracking<TEntity>(this DbSet<TEntity> @this, bool isNoTracking) where TEntity : class
        {
            if (@this == null)
            {
                throw new ArgumentNullException(nameof(@this));
            }
            return isNoTracking ? @this.AsNoTracking() : @this.AsQueryable();
        }
    }
}