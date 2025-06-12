namespace FinanceTracking.DAL.Models;

public enum UserStatus
{
    Active,
    Inactive
}

public sealed class UserModel : BaseModel
{
    public string FirstName { get; set; } = default!;
    public string? LastName { get; set; }
    public string Email { get; set; } = default!;
    public string Username { get; set; } = default!;
    public string PasswordHash { get; set; } = default!;
    public UserStatus Status { get; set; } = default!;
    public ICollection<TransactionModel> Transactions { get; set; } = [];
}
