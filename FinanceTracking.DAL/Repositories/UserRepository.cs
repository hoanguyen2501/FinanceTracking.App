using FinanceTracking.DAL.Entities;
using FinanceTracking.DAL.Interfaces;
using FinanceTracking.DAL.Models;
using FinanceTracking.DAL.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FinanceTracking.DAL.Repositories;

public sealed class UserRepository : AbstractEntityRepository<UserEntity>, IUserRepository
{
    public UserRepository(IServiceProvider provider, ILogger<UserRepository> logger) : base(provider, logger)
    {
    }

    #region Commands
    public async Task CreateAsync(UserModel model, CancellationToken ct = default)
    {
        var createEntity = Mapper.Map<UserEntity>(model);
        Context.Add(createEntity);
        await SaveChangesAsync(ct);
        GatherId(model, createEntity);
    }

    public async Task UpdateAsync(UserModel model, CancellationToken ct = default)
    {
        var entity = await GetEntityByIdAsync(model.Id, false, ct) ?? throw new Exception($"User with Id='{model.Id}' does not exist.");
        Mapper.Map(model, entity);
        Context.Update(entity);
        await SaveChangesAsync(ct);
    }

    public async Task DeleteAsync(UserModel model, CancellationToken ct = default)
    {
        var entity = await GetEntityByIdAsync(model.Id, false, ct) ?? throw new Exception($"User with Id='{model.Id}' does not exist.");
        Context.Entry(entity).State = EntityState.Deleted;
        await SaveChangesAsync(ct);
    }

    protected override void AttachExistingEntities(UserEntity model)
    {
        throw new NotImplementedException();
    }

    private static void GatherId(UserModel model, UserEntity entity) =>
        model.Id = entity.Id;
    #endregion

    #region Queries
    public async Task<UserModel?> GetByIdAsync(string id, CancellationToken ct = default)
    {
        var entity = await GetEntityByIdAsync(id, true, ct);
        return Mapper.Map<UserModel>(entity);
    }

    public async Task<IEnumerable<UserModel>> GetAllAsync(CancellationToken ct = default)
    {
        var entities = await GetQueryable(true, false).ToListAsync(ct);
        return entities.Select(Mapper.Map<UserModel>);
    }

    public async Task<IEnumerable<UserModel>> GetManyByIdsAsync(IEnumerable<string> ids, CancellationToken ct = default)
    {
        var entities = await GetEntitiesByIdsAsync(ids, true, ct);
        return entities.Select(Mapper.Map<UserModel>);
    }

    protected override async Task<UserEntity?> GetEntityByIdAsync(string id, bool isNoTracking = true, CancellationToken ct = default) =>
        await GetQueryable(isNoTracking).FirstOrDefaultAsync(e => e.Id == id, ct);

    protected override async Task<IEnumerable<UserEntity>> GetEntitiesByIdsAsync(IEnumerable<string> ids, bool isNoTracking = true, CancellationToken ct = default) =>
        await GetQueryable(isNoTracking).Where(e => ids.Contains(e.Id)).ToListAsync(ct);

    protected override IQueryable<UserEntity> GetQueryable(bool isNoTracking = false, bool hasInclude = true)
    {
        var entities = Context.Users.AsNoTracking(isNoTracking);

        return hasInclude ?
            entities.Include(c => c.Transactions) :
            entities;
    }
    #endregion
}
