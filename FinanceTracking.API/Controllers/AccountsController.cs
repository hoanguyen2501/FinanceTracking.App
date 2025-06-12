using FinanceTracking.API.DTOs;
using FinanceTracking.BLL.Interfaces;
using FinanceTracking.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinanceTracking.API.Controllers;

public class AccountsController : BaseController<IAccountService>
{
    public AccountsController(ILogger<AccountsController> logger) : base(logger)
    {
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync(CancellationToken ct = default)
    {
        IEnumerable<AccountModel> accounts = await Service.GetAllAsync(ct);
        return Ok(accounts.Select(Mapper.Map<AccountDTO>));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(string id, CancellationToken ct = default)
    {
        AccountModel? account = await Service.GetByIdAsync(id, ct);
        return Ok(Mapper.Map<AccountDTO>(account));
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateAccountDTO account, CancellationToken ct = default)
    {
        AccountModel model = Mapper.Map<AccountModel>(account);
        await Service.CreateAsync(model, ct);
        return Ok(Mapper.Map<AccountDTO>(account));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(string id, [FromBody] UpdateAccountDTO account, CancellationToken ct = default)
    {
        AccountModel model = Mapper.Map<AccountModel>(account);
        await Service.UpdateAsync(model, ct);
        return Ok(Mapper.Map<AccountDTO>(account));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(string id, CancellationToken ct = default)
    {
        await Service.DeleteAsync(id, ct);
        return NoContent();
    }
}