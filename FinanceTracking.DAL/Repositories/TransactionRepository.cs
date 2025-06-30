using FinanceTracking.DAL.Entities;
using FinanceTracking.DAL.Interfaces;
using FinanceTracking.DAL.Models;
using FinanceTracking.DAL.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FinanceTracking.DAL.Repositories;

public sealed class TransactionRepository : AbstractEntityRepository<TransactionEntity>, ITransactionRepository
{
    public TransactionRepository(IServiceProvider provider, ILogger<TransactionRepository> logger) : base(provider, logger)
    { }

    #region Commands
    public async Task CreateAsync(TransactionModel model, CancellationToken ct = default)
    {
        var createEntity = Mapper.Map<TransactionEntity>(model);
        // AttachExistingEntities(createEntity);
        Context.Add(createEntity);
        await SaveChangesAsync(ct);
        GatherId(model, createEntity);
    }

    public async Task UpdateAsync(TransactionModel model, CancellationToken ct = default)
    {
        var entity = await GetEntityByIdAsync(model.Id, true, ct) ?? throw new Exception($"Transaction with Id='{model.Id}' does not exist.");
        Mapper.Map(model, entity);
        Context.Update(entity);
        await SaveChangesAsync(ct);
    }

    public async Task DeleteAsync(TransactionModel model, CancellationToken ct = default)
    {
        var entity = await GetEntityByIdAsync(model.Id, false, ct) ?? throw new Exception($"Transaction with Id='{model.Id}' does not exist.");
        Context.Entry(entity).State = EntityState.Deleted;
        await SaveChangesAsync(ct);
    }

    protected override void AttachExistingEntities(TransactionEntity model)
    {
        Context.Entry(model.Category).State
            = Context.Entry(model.Account).State
            = Context.Entry(model.Member).State
            = Context.Entry(model.User).State
            = EntityState.Unchanged;
    }

    private static void GatherId(TransactionModel model, TransactionEntity entity) =>
        model.Id = entity.Id;
    #endregion

    #region Queries

    public async Task<IEnumerable<TransactionModel>> GetAllAsync(CancellationToken ct = default)
    {
        var entities = await GetQueryable(true).ToListAsync(ct);
        return entities.Select(Mapper.Map<TransactionModel>);
    }

    public async Task<TransactionModel?> GetByIdAsync(string id, CancellationToken ct = default)
    {
        var entity = await GetEntityByIdAsync(id, true, ct);
        return Mapper.Map<TransactionModel>(entity);
    }

    public async Task<IEnumerable<TransactionModel>> GetManyByIdsAsync(IEnumerable<string> ids, CancellationToken ct = default)
    {
        var entities = await GetEntitiesByIdsAsync(ids, true, ct);
        return entities.Select(Mapper.Map<TransactionModel>);
    }

    protected override async Task<TransactionEntity?> GetEntityByIdAsync(string id, bool isNoTracking = true, CancellationToken ct = default) =>
        await GetQueryable(isNoTracking).FirstOrDefaultAsync(e => e.Id == id, ct);

    protected override async Task<IEnumerable<TransactionEntity>> GetEntitiesByIdsAsync(IEnumerable<string> ids, bool isNoTracking = true, CancellationToken ct = default) =>
        await GetQueryable(isNoTracking).Where(e => ids.Contains(e.Id)).ToListAsync(ct);

    protected override IQueryable<TransactionEntity> GetQueryable(bool isNoTracking = false, bool hasInclude = true)
    {
        var entities = Context.Transactions.AsNoTracking(isNoTracking);
        return hasInclude ?
            entities.Include(e => e.Category)
                    .Include(e => e.Account)
                        .ThenInclude(e => e.AccountType)
                    .Include(e => e.Member)
                    .Include(e => e.User) :
            entities;
    }
    #endregion
}
