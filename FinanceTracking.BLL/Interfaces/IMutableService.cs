namespace FinanceTracking.BLL.Interfaces
{
    public interface IMutableService<T> where T : class
    {
        Task<T> CreateAsync(T model, CancellationToken ct = default);
        Task<T> UpdateAsync(T model, CancellationToken ct = default);
        Task DeleteAsync(string id, CancellationToken ct = default);
    }
}
