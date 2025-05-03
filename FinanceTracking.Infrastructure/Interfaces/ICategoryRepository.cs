using FinanceTracking.Infrastructure.Models;

namespace FinanceTracking.Infrastructure.Interfaces
{
    public interface ICategoryRepository : IRepository<CategoryModel>, IMutableRepository<CategoryModel>
    {
    }
}
