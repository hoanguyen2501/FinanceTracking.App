namespace FinanceTracking.Domain.Entities
{
    public sealed class AccountTypeEntity : BaseEntity
    {
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public ICollection<AccountEntity> Accounts { get; set; } = [];
    }
}
