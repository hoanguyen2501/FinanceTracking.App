namespace FinanceTracking.BLL.Interfaces
{
    public interface IService<T> where T : class
    {
        Task<T?> GetByIdAsync(string id, CancellationToken ct = default);
        Task<IEnumerable<T>> GetAllAsync(CancellationToken ct = default);
        Task<IEnumerable<T>> GetManyIdsAsync(IEnumerable<string> ids, CancellationToken ct = default);
    }
}
