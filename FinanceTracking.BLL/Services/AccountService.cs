using FinanceTracking.BLL.Interfaces;
using FinanceTracking.DAL.Interfaces;
using FinanceTracking.DAL.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FinanceTracking.BLL.Services
{
    public sealed class AccountService : AbstractBaseService, IAccountService
    {
        private readonly IAccountRepository _repository;
        public AccountService(IServiceProvider provider, ILogger<AccountService> logger) : base(provider, logger)
        {
            _repository = provider.GetRequiredService<IAccountRepository>();
        }

        public async Task<AccountModel> CreateAsync(AccountModel model, CancellationToken ct = default)
        {
            await _repository.CreateAsync(model, ct);
            return model;
        }

        public async Task DeleteAsync(string id, CancellationToken ct = default)
        {
            var model = await _repository.GetByIdAsync(id, ct) ?? throw new Exception($"Account with Id='{id}' does not exist.");
            await _repository.DeleteAsync(model, ct);
        }

        public async Task<AccountModel?> GetByIdAsync(string id, CancellationToken ct = default) =>
            await _repository.GetByIdAsync(id, ct);

        public async Task<IEnumerable<AccountModel>> GetAllAsync(CancellationToken ct = default) =>
            await _repository.GetAllAsync(ct);

        public async Task<IEnumerable<AccountModel>> GetManyIdsAsync(IEnumerable<string> ids, CancellationToken ct = default) =>
            await _repository.GetManyByIdsAsync(ids, ct);

        public async Task<AccountModel> UpdateAsync(AccountModel model, CancellationToken ct = default)
        {
            await _repository.UpdateAsync(model, ct);
            return model;
        }
    }
}
