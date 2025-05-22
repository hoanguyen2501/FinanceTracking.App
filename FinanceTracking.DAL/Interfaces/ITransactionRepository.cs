using FinanceTracking.DAL.Models;

namespace FinanceTracking.DAL.Interfaces
{
    public interface ITransactionRepository : IRepository<TransactionModel>, IMutableRepository<TransactionModel>
    { }
}
