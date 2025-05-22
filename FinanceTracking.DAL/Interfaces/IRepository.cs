namespace FinanceTracking.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(string id, CancellationToken ct = default);
        Task<IEnumerable<T>> GetAllAsync(CancellationToken ct = default);
        Task<IEnumerable<T>> GetManyByIdsAsync(IEnumerable<string> ids, CancellationToken ct = default);
    }
}
