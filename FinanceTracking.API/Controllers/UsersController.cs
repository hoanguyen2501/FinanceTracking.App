using FinanceTracking.API.DTOs;
using FinanceTracking.BLL.Interfaces;
using FinanceTracking.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinanceTracking.API.Controllers;

public class UsersController : BaseController<IUserService>
{
    public UsersController(ILogger<UsersController> logger) : base(logger)
    {
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync(CancellationToken ct = default)
    {
        IEnumerable<UserModel> users = await Service.GetAllAsync(ct);
        return Ok(users.Select(Mapper.Map<UserDTO>));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(string id, CancellationToken ct = default)
    {
        UserModel? user = await Service.GetByIdAsync(id, ct);
        return Ok(Mapper.Map<UserDTO>(user));
    }
}