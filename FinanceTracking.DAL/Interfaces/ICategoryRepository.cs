using FinanceTracking.DAL.Models;

namespace FinanceTracking.DAL.Interfaces
{
    public interface ICategoryRepository : IRepository<CategoryModel>, IMutableRepository<CategoryModel>
    { }
}