namespace FinanceTracking.DAL.Interfaces
{
    public interface IMutableRepository<T> where T : class
    {
        Task CreateAsync(T model, CancellationToken ct = default);
        Task UpdateAsync(T model, CancellationToken ct = default);
        Task DeleteAsync(T model, CancellationToken ct = default);
    }
}
