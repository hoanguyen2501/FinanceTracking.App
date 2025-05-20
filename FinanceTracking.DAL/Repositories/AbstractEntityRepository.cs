using System.Linq.Expressions;
using FinanceTracking.DAL.DataAccess;
using FinanceTracking.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FinanceTracking.DAL.Repositories
{
    public abstract class AbstractEntityRepository<T> : AbstractBaseRepository where T : class
    {
        protected FinanceTrackingDbContext Context { get; }

        public AbstractEntityRepository(IServiceProvider provider, ILogger logger) : base(provider, logger)
        {
            Context = provider.GetRequiredService<FinanceTrackingDbContext>();
        }

        public virtual async Task<IEnumerable<T>> GetManyAsync(Expression<Func<T, bool>> predicate, bool isNoTracking = true, CancellationToken token = default) =>
            await GetQueryable(isNoTracking).Where(predicate).ToListAsync(token);

        protected async Task SaveChangesAsync(CancellationToken ct = default)
        {
            try
            {
                await Context.SaveChangesAsync(ct);
            }
            catch (DbUpdateConcurrencyException exception)
            {
                var entries = exception.Entries;
                foreach (var entry in entries)
                {
                    Logger.LogError("Saving change with error: {EntityName}", entry.Entity);
                }
                throw;
            }
        }

        protected abstract IQueryable<T> GetQueryable(bool isNoTracking = false);
    }
}
