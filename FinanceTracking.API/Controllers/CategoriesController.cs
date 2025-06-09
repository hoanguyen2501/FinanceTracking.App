using FinanceTracking.API.DTOs;
using FinanceTracking.BLL.Interfaces;
using FinanceTracking.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinanceTracking.API.Controllers;

public sealed class CategoriesController : BaseController<ICategoryService>
{
    public CategoriesController(ILogger<CategoriesController> logger) : base(logger)
    {
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync(CancellationToken ct = default)
    {
        IEnumerable<CategoryModel> categories = await Service.GetAllAsync(ct);
        return Ok(categories.Select(Mapper.Map<CategoryDTO>));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(string id, CancellationToken ct = default)
    {
        CategoryModel? category = await Service.GetByIdAsync(id, ct);
        return Ok(category);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateCategoryDTO category, CancellationToken ct = default)
    {
        CategoryModel model = Mapper.Map<CategoryModel>(category);
        await Service.CreateAsync(model, ct);
        return Ok(model);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(string id, [FromBody] UpdateCategoryDTO category, CancellationToken ct = default)
    {
        CategoryModel model = Mapper.Map<CategoryModel>(category);
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
