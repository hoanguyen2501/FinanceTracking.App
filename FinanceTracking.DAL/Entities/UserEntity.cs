namespace FinanceTracking.DAL.Entities;

public sealed class UserEntity : BaseEntity
{
    public string FirstName { get; set; } = default!;
    public string? LastName { get; set; }
    public string Email { get; set; } = default!;
    public string Username { get; set; } = default!;
    public string PasswordHash { get; set; } = default!;
    public bool IsActive { get; set; } = default!;
    public ICollection<TransactionEntity> Transactions { get; set; } = [];
}
