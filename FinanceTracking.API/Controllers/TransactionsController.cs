using FinanceTracking.API.DTOs;
using FinanceTracking.BLL.Interfaces;
using FinanceTracking.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinanceTracking.API.Controllers;

public sealed class TransactionsController : BaseController<ITransactionService>
{
    public TransactionsController(ILogger<TransactionsController> logger) : base(logger)
    {
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync(CancellationToken ct = default)
    {
        IEnumerable<TransactionModel> transactions = await Service.GetAllAsync(ct);
        return Ok(transactions.Select(Mapper.Map<TransactionDTO>));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(string id, CancellationToken ct = default)
    {
        TransactionModel? transaction = await Service.GetByIdAsync(id, ct);
        return Ok(Mapper.Map<TransactionDTO>(transaction));
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateTransactionDTO category, CancellationToken ct = default)
    {
        TransactionModel model = Mapper.Map<TransactionModel>(category);
        await Service.CreateAsync(model, ct);
        return Ok(Mapper.Map<TransactionDTO>(model));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(string id, [FromBody] UpdateTransactionDTO category, CancellationToken ct = default)
    {
        TransactionModel model = Mapper.Map<TransactionModel>(category);
        await Service.UpdateAsync(model, ct);
        return Ok(Mapper.Map<TransactionDTO>(model));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(string id, CancellationToken ct = default)
    {
        await Service.DeleteAsync(id, ct);
        return NoContent();
    }
}