using FinanceTracking.DAL.Models;

namespace FinanceTracking.BLL.Interfaces
{
    public interface IUserService : IService<UserModel>, IMutableService<UserModel>
    {
    }
}
