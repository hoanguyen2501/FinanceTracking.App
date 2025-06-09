using FinanceTracking.DAL.Entities;
using FinanceTracking.DAL.Interfaces;
using FinanceTracking.DAL.Models;
using FinanceTracking.DAL.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FinanceTracking.DAL.Repositories
{
    public sealed class CategoryRepository : AbstractEntityRepository<CategoryEntity>, ICategoryRepository
    {
        public CategoryRepository(IServiceProvider provider, ILogger<CategoryRepository> logger) : base(provider, logger)
        {
        }

        #region Command
        public async Task CreateAsync(CategoryModel model, CancellationToken ct = default)
        {
            var createEntity = Mapper.Map<CategoryEntity>(model);
            Context.Add(createEntity);
            await SaveChangesAsync(ct);
            GatherId(model, createEntity);
        }

        public async Task UpdateAsync(CategoryModel model, CancellationToken ct = default)
        {
            var entity = await GetEntityByIdAsync(model.Id, false, ct) ?? throw new Exception($"Category with Id='{model.Id}' does not exist.");
            Mapper.Map(model, entity);
            Context.Update(entity);
            await SaveChangesAsync(ct);
        }

        public async Task DeleteAsync(CategoryModel model, CancellationToken ct = default)
        {
            var entity = await GetEntityByIdAsync(model.Id, false, ct) ?? throw new Exception($"Category with Id='{model.Id}' does not exist.");
            Context.Entry(entity).State = EntityState.Deleted;
            await SaveChangesAsync(ct);
        }

        private static void GatherId(CategoryModel model, CategoryEntity entity) =>
            model.Id = entity.Id;
        #endregion

        #region Query
        public async Task<CategoryModel?> GetByIdAsync(string id, CancellationToken ct = default)
        {
            var entity = await GetEntityByIdAsync(id, true, ct);
            return Mapper.Map<CategoryModel>(entity);
        }

        public async Task<IEnumerable<CategoryModel>> GetAllAsync(CancellationToken ct = default)
        {
            var entities = await GetQueryable(true, false).ToListAsync(ct);
            return entities.Select(Mapper.Map<CategoryModel>);
        }

        public async Task<IEnumerable<CategoryModel>> GetManyByIdsAsync(IEnumerable<string> ids, CancellationToken ct = default)
        {
            var entities = await GetEntitiesByIdsAsync(ids, true, ct);
            return entities.Select(Mapper.Map<CategoryModel>);
        }

        protected override async Task<CategoryEntity?> GetEntityByIdAsync(string id, bool isNoTracking = true, CancellationToken ct = default) =>
            await GetQueryable(isNoTracking).FirstOrDefaultAsync(e => e.Id == id, ct);

        protected override async Task<IEnumerable<CategoryEntity>> GetEntitiesByIdsAsync(IEnumerable<string> ids, bool isNoTracking = true, CancellationToken ct = default) =>
            await GetQueryable(isNoTracking).Where(e => ids.Contains(e.Id)).ToListAsync(ct);

        protected override IQueryable<CategoryEntity> GetQueryable(bool isNoTracking = false, bool hasInclude = true)
        {
            var entities = Context.Categories.AsNoTracking(isNoTracking);

            return hasInclude ?
                entities.Include(c => c.Transactions).ThenInclude(t => t.Account)
                        .Include(c => c.Transactions).ThenInclude(t => t.Member)
                        .Include(c => c.Transactions).ThenInclude(t => t.User) :
                entities;
        }
        #endregion
    }
}
