using FinanceTracking.DAL.Models;

namespace FinanceTracking.DAL.Interfaces
{
    public interface IMemberRepository : IRepository<MemberModel>, IMutableRepository<MemberModel>
    {
    }
}
