namespace FinanceTracking.DAL.Models
{
    public sealed class AccountModel : BaseModel
    {
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public AccountTypeModel AccountType { get; set; } = default!;
        public ICollection<TransactionModel> Transactions { get; set; } = [];
    }
}
