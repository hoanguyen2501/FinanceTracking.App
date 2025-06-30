namespace FinanceTracking.API.DTOs;

public sealed class TransactionDTO
{
    public DateTimeOffset TransactionDate { get; set; }
    public string? Description { get; set; }
    public decimal Amount { get; set; }
    public CategoryDTO Category { get; set; } = default!;
    public AccountDTO Account { get; set; } = default!;
    public MemberDTO Member { get; set; } = default!;
    public UserDTO User { get; set; } = default!;
}

public sealed class CreateTransactionDTO
{
    public DateTimeOffset TransactionDate { get; set; }
    public string? Description { get; set; }
    public decimal Amount { get; set; }
    public string CategoryId { get; set; } = default!;
    public string AccountId { get; set; } = default!;
    public string MemberId { get; set; } = default!;
    public string UserId { get; set; } = default!;
}

public sealed class UpdateTransactionDTO
{
    public string Id { get; set; } = default!;
    public DateTimeOffset TransactionDate { get; set; }
    public string? Description { get; set; }
    public decimal Amount { get; set; }
    public string CategoryId { get; set; } = default!;
    public string AccountId { get; set; } = default!;
    public string MemberId { get; set; } = default!;
    public string UserId { get; set; } = default!;
}