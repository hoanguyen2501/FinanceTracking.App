using FinanceTracking.API.DTOs;
using FinanceTracking.BLL.Interfaces;
using FinanceTracking.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinanceTracking.API.Controllers
{
    [Route("api/[controller]")]
    public sealed class CategoriesController : BaseController<ICategoryService>
    {
        public CategoriesController(ILogger<CategoriesController> logger) : base(logger)
        {
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllAsync(string id, CancellationToken ct = default)
        {
            var categories = await Service.GetByIdAsync(id, ct);
            return Ok(categories);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateCategoryDTO category, CancellationToken ct = default)
        {
            var model = Mapper.Map<CategoryModel>(category);
            await Service.CreateAsync(model, ct);
            return Ok(model);
        }
    }
}
