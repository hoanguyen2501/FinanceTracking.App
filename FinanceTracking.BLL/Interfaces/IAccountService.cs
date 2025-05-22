using FinanceTracking.DAL.Models;

namespace FinanceTracking.BLL.Interfaces
{
    public interface IAccountService : IService<AccountModel>, IMutableService<AccountModel>
    {
    }
}
