using FinanceTracking.BLL.Interfaces;
using FinanceTracking.DAL.Interfaces;
using FinanceTracking.DAL.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FinanceTracking.BLL.Services
{
    public sealed class UserService : AbstractBaseService, IUserService
    {
        private readonly IUserRepository _repository;
        public UserService(IServiceProvider provider, ILogger<UserService> logger) : base(provider, logger)
        {
            _repository = provider.GetRequiredService<IUserRepository>();
        }

        public async Task<UserModel> CreateAsync(UserModel model, CancellationToken ct = default)
        {
            await _repository.CreateAsync(model, ct);
            return model;
        }

        public async Task DeleteAsync(string id, CancellationToken ct = default)
        {
            var model = await _repository.GetByIdAsync(id, ct) ?? throw new Exception($"User with Id='{id}' does not exist.");
            await _repository.DeleteAsync(model, ct);
        }

        public async Task<UserModel?> GetByIdAsync(string id, CancellationToken ct = default) =>
            await _repository.GetByIdAsync(id, ct);

        public async Task<IEnumerable<UserModel>> GetAllAsync(CancellationToken ct = default) =>
            await _repository.GetAllAsync(ct);

        public async Task<IEnumerable<UserModel>> GetManyIdsAsync(IEnumerable<string> ids, CancellationToken ct = default) =>
            await _repository.GetManyByIdsAsync(ids, ct);

        public async Task<UserModel> UpdateAsync(UserModel model, CancellationToken ct = default)
        {
            await _repository.UpdateAsync(model, ct);
            return model;
        }
    }
}
