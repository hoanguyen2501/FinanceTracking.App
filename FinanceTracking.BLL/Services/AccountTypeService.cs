using FinanceTracking.BLL.Interfaces;
using FinanceTracking.DAL.Interfaces;
using FinanceTracking.DAL.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FinanceTracking.BLL.Services
{
    public sealed class AccountTypeService : AbstractBaseService, IAccountTypeService
    {
        private readonly IAccountTypeRepository _repository;
        public AccountTypeService(IServiceProvider provider, ILogger<AccountTypeService> logger) : base(provider, logger)
        {
            _repository = provider.GetRequiredService<IAccountTypeRepository>();
        }

        public async Task<AccountTypeModel> CreateAsync(AccountTypeModel model, CancellationToken ct = default)
        {
            await _repository.CreateAsync(model, ct);
            return model;
        }

        public async Task DeleteAsync(string id, CancellationToken ct = default)
        {
            var model = await _repository.GetByIdAsync(id, ct) ?? throw new Exception($"AccountType with Id='{id}' does not exist.");
            await _repository.DeleteAsync(model, ct);
        }

        public async Task<AccountTypeModel?> GetByIdAsync(string id, CancellationToken ct = default) =>
            await _repository.GetByIdAsync(id, ct);

        public async Task<IEnumerable<AccountTypeModel>> GetAllAsync(CancellationToken ct = default) =>
            await _repository.GetAllAsync(ct);

        public async Task<IEnumerable<AccountTypeModel>> GetManyIdsAsync(IEnumerable<string> ids, CancellationToken ct = default) =>
            await _repository.GetManyByIdsAsync(ids, ct);

        public async Task<AccountTypeModel> UpdateAsync(AccountTypeModel model, CancellationToken ct = default)
        {
            await _repository.UpdateAsync(model, ct);
            return model;
        }
    }
}
