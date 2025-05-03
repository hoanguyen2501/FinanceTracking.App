namespace FinanceTracking.Domain.Entities
{
    public sealed class AccountEntity : BaseEntity
    {
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public string AccountTypeId { get; set; } = default!;
        public AccountTypeEntity AccountType { get; set; } = default!;
        public ICollection<TransactionEntity> Transactions { get; set; } = [];
    }
}
