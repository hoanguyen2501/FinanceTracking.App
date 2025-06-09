using FinanceTracking.DAL.Models;

namespace FinanceTracking.DAL.Interfaces
{
    public interface IAccountRepository : IRepository<AccountModel>, IMutableRepository<AccountModel>
    { }
}