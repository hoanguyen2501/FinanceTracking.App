namespace FinanceTracking.Infrastructure.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity?> GetByIdAsync(string id, CancellationToken ct = default);
        Task<IEnumerable<TEntity>> GetManyByIdsAsync(IEnumerable<string> ids, CancellationToken ct = default);
    }
}
