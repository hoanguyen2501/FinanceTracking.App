using FinanceTracking.API.DTOs;
using FinanceTracking.BLL.Interfaces;
using FinanceTracking.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinanceTracking.API.Controllers;

public class MembersController : BaseController<IMemberService>
{
    public MembersController(ILogger<MembersController> logger) : base(logger)
    {
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync(CancellationToken ct = default)
    {
        IEnumerable<MemberModel> members = await Service.GetAllAsync(ct);
        return Ok(members.Select(Mapper.Map<MemberDTO>));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(string id, CancellationToken ct = default)
    {
        MemberModel? member = await Service.GetByIdAsync(id, ct);
        return Ok(Mapper.Map<MemberDTO>(member));
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateMemberDTO category, CancellationToken ct = default)
    {
        MemberModel model = Mapper.Map<MemberModel>(category);
        await Service.CreateAsync(model, ct);
        return Ok(Mapper.Map<MemberDTO>(model));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(string id, [FromBody] UpdateMemberDTO category, CancellationToken ct = default)
    {
        MemberModel model = Mapper.Map<MemberModel>(category);
        await Service.UpdateAsync(model, ct);
        return Ok(Mapper.Map<MemberDTO>(model));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(string id, CancellationToken ct = default)
    {
        await Service.DeleteAsync(id, ct);
        return NoContent();
    }
}