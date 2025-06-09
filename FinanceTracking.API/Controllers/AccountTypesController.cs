using FinanceTracking.API.DTOs;
using FinanceTracking.BLL.Interfaces;
using FinanceTracking.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinanceTracking.API.Controllers;

[Route("api/account-types")]
public class AccountTypesController : BaseController<IAccountTypeService>
{
    public AccountTypesController(ILogger<AccountTypesController> logger) : base(logger)
    {
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync(CancellationToken ct = default)
    {
        IEnumerable<AccountTypeModel> accounts = await Service.GetAllAsync(ct);
        return Ok(accounts.Select(Mapper.Map<AccountTypeDTO>));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(string id, CancellationToken ct = default)
    {
        AccountTypeModel? account = await Service.GetByIdAsync(id, ct);
        return Ok(account);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateAccountTypeDTO account, CancellationToken ct = default)
    {
        AccountTypeModel model = Mapper.Map<AccountTypeModel>(account);
        await Service.CreateAsync(model, ct);
        return Ok(model);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(string id, [FromBody] UpdateAccountTypeDTO account, CancellationToken ct = default)
    {
        AccountTypeModel model = Mapper.Map<AccountTypeModel>(account);
        await Service.UpdateAsync(model, ct);
        return Ok(model);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(string id, CancellationToken ct = default)
    {
        await Service.DeleteAsync(id, ct);
        return NoContent();
    }
}