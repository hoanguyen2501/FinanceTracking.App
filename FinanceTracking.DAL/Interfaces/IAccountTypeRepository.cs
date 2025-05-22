using FinanceTracking.DAL.Models;

namespace FinanceTracking.DAL.Interfaces
{
    public interface IAccountTypeRepository : IRepository<AccountTypeModel>, IMutableRepository<AccountTypeModel>
    {
    }
}
