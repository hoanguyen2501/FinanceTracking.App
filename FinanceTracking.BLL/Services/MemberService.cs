using FinanceTracking.BLL.Interfaces;
using FinanceTracking.DAL.Interfaces;
using FinanceTracking.DAL.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FinanceTracking.BLL.Services
{
    public sealed class MemberService : AbstractBaseService, IMemberService
    {
        private readonly IMemberRepository _repository;
        public MemberService(IServiceProvider provider, ILogger<MemberService> logger) : base(provider, logger)
        {
            _repository = provider.GetRequiredService<IMemberRepository>();
        }

        public async Task<MemberModel> CreateAsync(MemberModel model, CancellationToken ct = default)
        {
            await _repository.CreateAsync(model, ct);
            return model;
        }

        public async Task DeleteAsync(string id, CancellationToken ct = default)
        {
            var model = await _repository.GetByIdAsync(id, ct) ?? throw new Exception($"Member with Id='{id}' does not exist.");
            await _repository.DeleteAsync(model, ct);
        }

        public async Task<MemberModel?> GetByIdAsync(string id, CancellationToken ct = default) =>
            await _repository.GetByIdAsync(id, ct);

        public async Task<IEnumerable<MemberModel>> GetAllAsync(CancellationToken ct = default) =>
            await _repository.GetAllAsync(ct);

        public async Task<IEnumerable<MemberModel>> GetManyIdsAsync(IEnumerable<string> ids, CancellationToken ct = default) =>
            await _repository.GetManyByIdsAsync(ids, ct);

        public async Task<MemberModel> UpdateAsync(MemberModel model, CancellationToken ct = default)
        {
            await _repository.UpdateAsync(model, ct);
            return model;
        }
    }
}
