namespace FinanceTracking.Infrastructure.Interfaces
{
    public interface IMutableRepository<TModel> where TModel : class
    {
        Task CreateAsync(TModel model, CancellationToken ct = default);
        Task UpdateAsync(TModel model, CancellationToken ct = default);
        Task DeleteAsync(TModel model, CancellationToken ct = default);
    }
}
