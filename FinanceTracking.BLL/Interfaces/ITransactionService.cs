using FinanceTracking.DAL.Models;

namespace FinanceTracking.BLL.Interfaces
{
    public interface ITransactionService : IService<TransactionModel>, IMutableService<TransactionModel>
    {
    }
}
