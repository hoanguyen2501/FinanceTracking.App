using FinanceTracking.DAL.Models;

namespace FinanceTracking.DAL.Interfaces
{
    public interface IUserRepository : IRepository<UserModel>, IMutableRepository<UserModel>
    {
    }
}
