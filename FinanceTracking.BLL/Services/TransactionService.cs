using FinanceTracking.BLL.Interfaces;
using FinanceTracking.DAL.Interfaces;
using FinanceTracking.DAL.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FinanceTracking.BLL.Services
{
    public sealed class TransactionService : AbstractBaseService, ITransactionService
    {
        private readonly ITransactionRepository _repository;
        public TransactionService(IServiceProvider provider, ILogger<TransactionService> logger) : base(provider, logger)
        {
            _repository = provider.GetRequiredService<ITransactionRepository>();
        }

        public async Task<TransactionModel> CreateAsync(TransactionModel model, CancellationToken ct = default)
        {
            await _repository.CreateAsync(model, ct);
            return model;
        }

        public async Task DeleteAsync(string id, CancellationToken ct = default)
        {
            var model = await _repository.GetByIdAsync(id, ct) ?? throw new Exception($"Transaction with Id='{id}' does not exist.");
            await _repository.DeleteAsync(model, ct);
        }

        public async Task<TransactionModel?> GetByIdAsync(string id, CancellationToken ct = default) =>
            await _repository.GetByIdAsync(id, ct);

        public async Task<IEnumerable<TransactionModel>> GetAllAsync(CancellationToken ct = default) =>
            await _repository.GetAllAsync(ct);

        public async Task<IEnumerable<TransactionModel>> GetManyIdsAsync(IEnumerable<string> ids, CancellationToken ct = default) =>
            await _repository.GetManyByIdsAsync(ids, ct);

        public async Task<TransactionModel> UpdateAsync(TransactionModel model, CancellationToken ct = default)
        {
            await _repository.UpdateAsync(model, ct);
            return model;
        }
    }
}
