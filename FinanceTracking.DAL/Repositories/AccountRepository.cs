using FinanceTracking.DAL.Entities;
using FinanceTracking.DAL.Interfaces;
using FinanceTracking.DAL.Models;
using FinanceTracking.DAL.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FinanceTracking.DAL.Repositories;

public sealed class AccountRepository : AbstractEntityRepository<AccountEntity>, IAccountRepository
{
    public AccountRepository(IServiceProvider provider, ILogger<AccountRepository> logger) : base(provider, logger)
    {
    }

    #region Commands
    public async Task CreateAsync(AccountModel model, CancellationToken ct = default)
    {
        var createEntity = Mapper.Map<AccountEntity>(model);
        Context.Add(createEntity);
        await SaveChangesAsync(ct);
        GatherId(model, createEntity);
    }

    public async Task UpdateAsync(AccountModel model, CancellationToken ct = default)
    {
        var entity = await GetEntityByIdAsync(model.Id, false, ct) ?? throw new Exception($"Account with Id='{model.Id}' does not exist.");
        Mapper.Map(model, entity);
        Context.Update(entity);
        await SaveChangesAsync(ct);
    }

    public async Task DeleteAsync(AccountModel model, CancellationToken ct = default)
    {
        var entity = await GetEntityByIdAsync(model.Id, false, ct) ?? throw new Exception($"Account with Id='{model.Id}' does not exist.");
        Context.Entry(entity).State = EntityState.Deleted;
        await SaveChangesAsync(ct);
    }

    protected override void AttachExistingEntities(AccountEntity model)
    {
        throw new NotImplementedException();
    }

    private static void GatherId(AccountModel model, AccountEntity entity) =>
        model.Id = entity.Id;

    #endregion

    #region Queries
    public async Task<AccountModel?> GetByIdAsync(string id, CancellationToken ct = default)
    {
        var entity = await GetEntityByIdAsync(id, true, ct);
        return Mapper.Map<AccountModel>(entity);
    }

    public async Task<IEnumerable<AccountModel>> GetAllAsync(CancellationToken ct = default)
    {
        var entities = await GetQueryable(true, false).ToListAsync(ct);
        return entities.Select(Mapper.Map<AccountModel>);
    }

    public async Task<IEnumerable<AccountModel>> GetManyByIdsAsync(IEnumerable<string> ids, CancellationToken ct = default)
    {
        var entities = await GetEntitiesByIdsAsync(ids, true, ct);
        return entities.Select(Mapper.Map<AccountModel>);
    }

    protected override async Task<AccountEntity?> GetEntityByIdAsync(string id, bool isNoTracking = true, CancellationToken ct = default) =>
        await GetQueryable(isNoTracking).FirstOrDefaultAsync(e => e.Id == id, ct);

    protected override async Task<IEnumerable<AccountEntity>> GetEntitiesByIdsAsync(IEnumerable<string> ids, bool isNoTracking = true, CancellationToken ct = default) =>
        await GetQueryable(isNoTracking).Where(e => ids.Contains(e.Id)).ToListAsync(ct);

    protected override IQueryable<AccountEntity> GetQueryable(bool isNoTracking = false, bool hasInclude = true)
    {
        var entities = Context.Accounts.AsNoTracking(isNoTracking);

        return hasInclude ?
            entities.Include(e => e.Transactions) :
            entities;
    }

    #endregion
}
