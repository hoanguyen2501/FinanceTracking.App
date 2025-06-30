namespace FinanceTracking.DAL.Models;

public sealed class TransactionModel : BaseModel
{
    public DateTimeOffset TransactionDate { get; set; }
    public string? Description { get; set; }
    public decimal Amount { get; set; }
    public string CategoryId { get; set; } = default!;
    public string AccountId { get; set; } = default!;
    public string MemberId { get; set; } = default!;
    public string UserId { get; set; } = default!;
    public CategoryModel Category { get; set; } = default!;
    public AccountModel Account { get; set; } = default!;
    public MemberModel Member { get; set; } = default!;
    public UserModel User { get; set; } = default!;
}
