using FinanceTracking.BLL.Interfaces;
using FinanceTracking.DAL.Interfaces;
using FinanceTracking.DAL.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FinanceTracking.BLL.Services;

public sealed class TransactionService : AbstractBaseService, ITransactionService
{
    private readonly ITransactionRepository _repository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IAccountRepository _accountRepository;
    private readonly IMemberRepository _memberRepository;
    private readonly IUserRepository _userRepository;
    public TransactionService(IServiceProvider provider, ILogger<TransactionService> logger) : base(provider, logger)
    {
        _repository = provider.GetRequiredService<ITransactionRepository>();
        _categoryRepository = provider.GetRequiredService<ICategoryRepository>();
        _accountRepository = provider.GetRequiredService<IAccountRepository>();
        _memberRepository = provider.GetRequiredService<IMemberRepository>();
        _userRepository = provider.GetRequiredService<IUserRepository>();
    }

    #region Commands
    public async Task<TransactionModel> CreateAsync(TransactionModel model, CancellationToken ct = default)
    {
        // await PopulateDataAsync([model], ct);
        await _repository.CreateAsync(model, ct);
        return model;
    }

    public async Task DeleteAsync(string id, CancellationToken ct = default)
    {
        var model = await _repository.GetByIdAsync(id, ct) ?? throw new Exception($"Transaction with Id='{id}' does not exist.");
        await _repository.DeleteAsync(model, ct);
    }

    public async Task<TransactionModel> UpdateAsync(TransactionModel model, CancellationToken ct = default)
    {
        await _repository.UpdateAsync(model, ct);
        return model;
    }
    #endregion

    #region Queries
    public async Task<TransactionModel?> GetByIdAsync(string id, CancellationToken ct = default) =>
        await _repository.GetByIdAsync(id, ct);

    public async Task<IEnumerable<TransactionModel>> GetAllAsync(CancellationToken ct = default) =>
        await _repository.GetAllAsync(ct);

    public async Task<IEnumerable<TransactionModel>> GetManyIdsAsync(IEnumerable<string> ids, CancellationToken ct = default) =>
        await _repository.GetManyByIdsAsync(ids, ct);

    private async Task PopulateDataAsync(IEnumerable<TransactionModel> transactions, CancellationToken ct = default)
    {
        try
        {
            await PopulateCategoryAsync(transactions, ct);
            await PopulateAccountAsync(transactions, ct);
            await PopulateMemberAsync(transactions, ct);
            await PopulateUserAsync(transactions, ct);
        }
        catch (Exception)
        {
            throw;
        }
    }

    private async Task PopulateCategoryAsync(IEnumerable<TransactionModel> transactions, CancellationToken ct = default)
    {
        var categories = await _categoryRepository.GetManyByIdsAsync(transactions.Select(e => e.Category.Id), ct);
        foreach (var transaction in transactions)
        {
            var category = categories.FirstOrDefault(e => transaction.Category == e);
            if (category != null)
                transaction.Category = category;
        }
    }

    private async Task PopulateAccountAsync(IEnumerable<TransactionModel> transactions, CancellationToken ct = default)
    {
        try
        {
            var accounts = await _accountRepository.GetManyByIdsAsync(transactions.Select(e => e.Account.Id), ct);
            foreach (var transaction in transactions)
            {
                var account = accounts.FirstOrDefault(e => transaction.Account == e);
                if (account != null)
                    transaction.Account = account;
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

    private async Task PopulateMemberAsync(IEnumerable<TransactionModel> transactions, CancellationToken ct = default)
    {
        try
        {
            var members = await _memberRepository.GetManyByIdsAsync(transactions.Select(e => e.Member.Id), ct);
            foreach (var transaction in transactions)
            {
                var member = members.FirstOrDefault(e => transaction.Member == e);
                if (member != null)
                    transaction.Member = member;
            }
        }
        catch (Exception)
        {

            throw;
        }
    }

    private async Task PopulateUserAsync(IEnumerable<TransactionModel> transactions, CancellationToken ct = default)
    {
        try
        {
            var users = await _userRepository.GetManyByIdsAsync(transactions.Select(e => e.User.Id), ct);
            foreach (var transaction in transactions)
            {
                var user = users.FirstOrDefault(e => transaction.User == e);
                if (user != null)
                    transaction.User = user;
            }
        }
        catch (Exception)
        {

            throw;
        }
    }
    #endregion
}
