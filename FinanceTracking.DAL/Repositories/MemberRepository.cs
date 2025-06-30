using FinanceTracking.DAL.Entities;
using FinanceTracking.DAL.Interfaces;
using FinanceTracking.DAL.Models;
using FinanceTracking.DAL.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FinanceTracking.DAL.Repositories;

public sealed class MemberRepository : AbstractEntityRepository<MemberEntity>, IMemberRepository
{
    public MemberRepository(IServiceProvider provider, ILogger<MemberRepository> logger) : base(provider, logger)
    {
    }

    #region Commands
    public async Task CreateAsync(MemberModel model, CancellationToken ct = default)
    {
        var createEntity = Mapper.Map<MemberEntity>(model);
        Context.Add(createEntity);
        await SaveChangesAsync(ct);
        GatherId(model, createEntity);
    }

    public async Task UpdateAsync(MemberModel model, CancellationToken ct = default)
    {
        var entity = await GetEntityByIdAsync(model.Id, false, ct) ?? throw new Exception($"Member with Id='{model.Id}' does not exist.");
        Mapper.Map(model, entity);
        Context.Update(entity);
        await SaveChangesAsync(ct);
    }

    public async Task DeleteAsync(MemberModel model, CancellationToken ct = default)
    {
        var entity = await GetEntityByIdAsync(model.Id, false, ct) ?? throw new Exception($"Member with Id='{model.Id}' does not exist.");
        Context.Entry(entity).State = EntityState.Deleted;
        await SaveChangesAsync(ct);
    }

    protected override void AttachExistingEntities(MemberEntity  model)
    {
        throw new NotImplementedException();
    }

    private static void GatherId(MemberModel model, MemberEntity entity) =>
        model.Id = entity.Id;
    #endregion

    #region Queries
    public async Task<MemberModel?> GetByIdAsync(string id, CancellationToken ct = default)
    {
        var entity = await GetEntityByIdAsync(id, true, ct);
        return Mapper.Map<MemberModel>(entity);
    }

    public async Task<IEnumerable<MemberModel>> GetAllAsync(CancellationToken ct = default)
    {
        var entities = await GetQueryable(true, false).ToListAsync(ct);
        return entities.Select(Mapper.Map<MemberModel>);
    }

    public async Task<IEnumerable<MemberModel>> GetManyByIdsAsync(IEnumerable<string> ids, CancellationToken ct = default)
    {
        var entities = await GetEntitiesByIdsAsync(ids, true, ct);
        return entities.Select(Mapper.Map<MemberModel>);
    }

    protected override async Task<MemberEntity?> GetEntityByIdAsync(string id, bool isNoTracking = true, CancellationToken ct = default) =>
        await GetQueryable(isNoTracking).FirstOrDefaultAsync(e => e.Id == id, ct);

    protected override async Task<IEnumerable<MemberEntity>> GetEntitiesByIdsAsync(IEnumerable<string> ids, bool isNoTracking = true, CancellationToken ct = default) =>
        await GetQueryable(isNoTracking).Where(e => ids.Contains(e.Id)).ToListAsync(ct);

    protected override IQueryable<MemberEntity> GetQueryable(bool isNoTracking = false, bool hasInclude = true)
    {
        var entities = Context.Members.AsNoTracking(isNoTracking);

        return hasInclude ?
            entities.Include(c => c.Transactions) :
            entities;
    }
    #endregion
}
