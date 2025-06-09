using FinanceTracking.BLL.Interfaces;
using FinanceTracking.DAL.Interfaces;
using FinanceTracking.DAL.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FinanceTracking.BLL.Services;

public sealed class CategoryService : AbstractBaseService, ICategoryService
{
    private readonly ICategoryRepository _repository;
    public CategoryService(IServiceProvider provider, ILogger<CategoryService> logger) : base(provider, logger)
    {
        _repository = provider.GetRequiredService<ICategoryRepository>();
    }

    public async Task<CategoryModel> CreateAsync(CategoryModel model, CancellationToken ct = default)
    {
        await _repository.CreateAsync(model, ct);
        return model;
    }

    public async Task DeleteAsync(string id, CancellationToken ct = default)
    {
        var model = await _repository.GetByIdAsync(id, ct) ?? throw new Exception($"Category with Id='{id}' does not exist.");
        await _repository.DeleteAsync(model, ct);
    }

    public async Task<CategoryModel?> GetByIdAsync(string id, CancellationToken ct = default) =>
        await _repository.GetByIdAsync(id, ct);

    public async Task<IEnumerable<CategoryModel>> GetAllAsync(CancellationToken ct = default) =>
        await _repository.GetAllAsync(ct);

    public async Task<IEnumerable<CategoryModel>> GetManyIdsAsync(IEnumerable<string> ids, CancellationToken ct = default) =>
        await _repository.GetManyByIdsAsync(ids, ct);

    public async Task<CategoryModel> UpdateAsync(CategoryModel model, CancellationToken ct = default)
    {
        await _repository.UpdateAsync(model, ct);
        return model;
    }
}
