using AutoMapper;
using FinanceTracking.Domain.Entities;
using FinanceTracking.Infrastructure.Interfaces;
using FinanceTracking.Infrastructure.Models;
using FinanceTracking.Infrastructure.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FinanceTracking.Infrastructure.Repositories
{
    public sealed class CategoryRepository : AbstractBaseRepository<CategoryEntity>, ICategoryRepository
    {
        public CategoryRepository(IServiceProvider provider, IMapper mapper, ILogger logger) : base(provider, mapper, logger)
        {
        }

        public Task CreateAsync(CategoryModel model, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(CategoryModel model, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public async Task<CategoryModel?> GetByIdAsync(string id, CancellationToken ct = default)
        {
            var entity = await Context.Categories.FirstOrDefaultAsync(c => c.Id == id, ct);
            return Mapper.Map<CategoryModel>(entity);
        }

        public async Task<IEnumerable<CategoryModel>> GetManyByIdsAsync(IEnumerable<string> ids, CancellationToken ct = default)
        {
            var models = Context.Categories.Where(e => ids.Contains(e.Id)).Select(e => Mapper.Map<CategoryModel>(e));
            return await models.ToListAsync(ct);
        }

        public Task UpdateAsync(CategoryModel model, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        protected override IQueryable<CategoryEntity> GetQueryable(bool isNoTracking = false) =>
            Context.Categories
                .AsNoTracking(isNoTracking)
                .Include(c => c.Transactions)
                    .ThenInclude(c => c.Account)
                .Include(c => c.Transactions)
                    .ThenInclude(c => c.Member)
                .Include(c => c.Transactions)
                        .ThenInclude(c => c.User);
    }
}
