namespace FinanceTracking.DAL.Models
{
    public sealed class MemberModel : BaseModel
    {
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;
        public ICollection<TransactionModel> Transactions { get; set; } = [];
    }
}
