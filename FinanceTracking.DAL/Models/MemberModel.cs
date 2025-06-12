namespace FinanceTracking.DAL.Models;


public enum MemberStatus
{
    Active,
    Inactive
}
public sealed class MemberModel : BaseModel
{
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public MemberStatus Status { get; set; } = default!;
    public ICollection<TransactionModel> Transactions { get; set; } = [];
}
