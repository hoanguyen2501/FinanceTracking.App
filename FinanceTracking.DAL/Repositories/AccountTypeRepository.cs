using FinanceTracking.DAL.Entities;
using FinanceTracking.DAL.Interfaces;
using FinanceTracking.DAL.Models;
using FinanceTracking.DAL.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FinanceTracking.DAL.Repositories;

public sealed class AccountTypeRepository : AbstractEntityRepository<AccountTypeEntity>, IAccountTypeRepository
{
    public AccountTypeRepository(IServiceProvider provider, ILogger<AccountTypeRepository> logger) : base(provider, logger)
    {
    }

    #region Commands
    public async Task CreateAsync(AccountTypeModel model, CancellationToken ct = default)
    {
        var createEntity = Mapper.Map<AccountTypeEntity>(model);
        Context.Add(createEntity);
        await SaveChangesAsync(ct);
        GatherId(model, createEntity);
    }

    public async Task UpdateAsync(AccountTypeModel model, CancellationToken ct = default)
    {
        var entity = await GetEntityByIdAsync(model.Id, false, ct) ?? throw new Exception($"AccountType with Id='{model.Id}' does not exist.");
        Mapper.Map(model, entity);
        Context.Update(entity);
        await SaveChangesAsync(ct);
    }

    public async Task DeleteAsync(AccountTypeModel model, CancellationToken ct = default)
    {
        var entity = await GetEntityByIdAsync(model.Id, false, ct) ?? throw new Exception($"AccountType with Id='{model.Id}' does not exist.");
        Context.Entry(entity).State = EntityState.Deleted;
        await SaveChangesAsync(ct);
    }

    protected override void AttachExistingEntities(AccountTypeEntity model)
    {
        throw new NotImplementedException();
    }

    private static void GatherId(AccountTypeModel model, AccountTypeEntity entity) =>
        model.Id = entity.Id;
    #endregion

    #region Queries
    public async Task<AccountTypeModel?> GetByIdAsync(string id, CancellationToken ct = default)
    {
        var entity = await GetEntityByIdAsync(id, true, ct);
        return Mapper.Map<AccountTypeModel>(entity);
    }

    public async Task<IEnumerable<AccountTypeModel>> GetAllAsync(CancellationToken ct = default)
    {
        var entities = await GetQueryable(true, false).ToListAsync(ct);
        return entities.Select(Mapper.Map<AccountTypeModel>);
    }

    public async Task<IEnumerable<AccountTypeModel>> GetManyByIdsAsync(IEnumerable<string> ids, CancellationToken ct = default)
    {
        var entities = await GetEntitiesByIdsAsync(ids, true, ct);
        return entities.Select(Mapper.Map<AccountTypeModel>);
    }

    protected override async Task<AccountTypeEntity?> GetEntityByIdAsync(string id, bool isNoTracking = true, CancellationToken ct = default) =>
        await GetQueryable(isNoTracking).FirstOrDefaultAsync(e => e.Id == id, ct);

    protected override async Task<IEnumerable<AccountTypeEntity>> GetEntitiesByIdsAsync(IEnumerable<string> ids, bool isNoTracking = true, CancellationToken ct = default) =>
        await GetQueryable(isNoTracking).Where(e => ids.Contains(e.Id)).ToListAsync(ct);

    protected override IQueryable<AccountTypeEntity> GetQueryable(bool isNoTracking = false, bool hasInclude = true)
    {
        var entities = Context.AccountTypes.AsNoTracking(isNoTracking);

        return hasInclude ?
            entities.Include(c => c.Accounts):
            entities;
    }
    #endregion
}
