using System.Linq.Expressions;
using AutoMapper;
using FinanceTracking.Infrastructure.Data;
using FinanceTracking.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FinanceTracking.Infrastructure.Repositories
{
    public abstract class AbstractBaseRepository<T>
    {
        protected FinanceTrackingDbContext Context { get; }
        protected IMapper Mapper { get; }
        protected ILogger Logger { get; }

        protected AbstractBaseRepository(IServiceProvider provider, IMapper mapper, ILogger logger)
        {
            Context = provider.GetRequiredService<FinanceTrackingDbContext>();
            (Mapper, Logger) = (mapper, logger);
        }

        protected AbstractBaseRepository(IServiceProvider provider, ILogger logger)
        {
            Context = provider.GetRequiredService<FinanceTrackingDbContext>();
            Mapper = provider.GetRequiredService<IMapper>();
            Logger = logger;
        }

        protected abstract IQueryable<T> GetQueryable(bool isNoTracking = false);

        public virtual async Task<IEnumerable<T>> GetManyAsync(Expression<Func<T, bool>> predicate, CancellationToken ct = default) =>
            await GetQueryable(true).Where(predicate).ToListAsync(ct);

        protected async Task SaveChangeAsync(CancellationToken ct = default)
        {
            try
            {
                await Context.SaveChangesAsync(ct);
            }
            catch (DbUpdateException exception)
            {
                var entries = exception.Entries;
                foreach (var entry in entries)
                {
                    Logger.Error("Save DB Error with entry {EntityName}: \n{Entity}", nameof(entry.Entity), entry.Entity);
                }
                throw;
            }
        }
    }
}
