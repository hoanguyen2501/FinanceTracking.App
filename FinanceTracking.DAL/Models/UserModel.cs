namespace FinanceTracking.DAL.Models;

public enum UserStatus
{
    Active,
    Inactive
}

public sealed class UserModel : BaseModel, IEquatable<UserModel>
{
    public string FirstName { get; set; } = default!;
    public string? LastName { get; set; }
    public string Email { get; set; } = default!;
    public string Username { get; set; } = default!;
    public string PasswordHash { get; set; } = default!;
    public UserStatus Status { get; set; } = default!;
    public ICollection<TransactionModel> Transactions { get; set; } = [];

    public bool Equals(UserModel? other)
    {
        if (other == null)
            return false;
        if (ReferenceEquals(this, other))
            return true;

        return Id == other.Id;
    }
    public override int GetHashCode() => Id.GetHashCode();
    public override bool Equals(object? obj) => Equals(obj as UserModel);

    public static bool operator ==(UserModel? left, UserModel? right) => EqualityComparer<UserModel>.Default.Equals(left, right);

    public static bool operator !=(UserModel? left, UserModel? right) => !(left == right);
}
