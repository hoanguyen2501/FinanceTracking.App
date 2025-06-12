namespace FinanceTracking.DAL.Entities;

public sealed class MemberEntity : BaseEntity
{
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public bool IsActive { get; set; } = true;
    public ICollection<TransactionEntity> Transactions { get; set; } = [];
}
