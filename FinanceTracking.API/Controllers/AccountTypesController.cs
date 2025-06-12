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
        IEnumerable<AccountTypeModel> accountTypes = await Service.GetAllAsync(ct);
        return Ok(accountTypes.Select(Mapper.Map<AccountTypeDTO>));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(string id, CancellationToken ct = default)
    {
        AccountTypeModel? accountType = await Service.GetByIdAsync(id, ct);
        return Ok(Mapper.Map<AccountTypeDTO>(accountType));
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateAccountTypeDTO accountType, CancellationToken ct = default)
    {
        AccountTypeModel model = Mapper.Map<AccountTypeModel>(accountType);
        await Service.CreateAsync(model, ct);
        return Ok(Mapper.Map<AccountTypeDTO>(model));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(string id, [FromBody] UpdateAccountTypeDTO accountType, CancellationToken ct = default)
    {
        AccountTypeModel model = Mapper.Map<AccountTypeModel>(accountType);
        await Service.UpdateAsync(model, ct);
        return Ok(Mapper.Map<AccountTypeDTO>(model));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(string id, CancellationToken ct = default)
    {
        await Service.DeleteAsync(id, ct);
        return NoContent();
    }
}