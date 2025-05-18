namespace FinanceTracking.DAL.Entities
{
    public sealed class TransactionEntity : BaseEntity
    {
        public DateTimeOffset TransactionDate { get; set; }
        public string? Description { get; set; }
        public decimal Amount { get; set; }
        public string CategoryId { get; set; } = default!;
        public CategoryEntity Category { get; set; } = default!;
        public string AccountId { get; set; } = default!;
        public AccountEntity Account { get; set; } = default!;
        public string MemberId { get; set; } = default!;
        public MemberEntity Member { get; set; } = default!;
        public string UserId { get; set; } = default!;
        public UserEntity User { get; set; } = default!;
    }
}
