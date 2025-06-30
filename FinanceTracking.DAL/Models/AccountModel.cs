namespace FinanceTracking.DAL.Models;

public sealed class AccountModel : BaseModel, IEquatable<AccountModel>
{
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public AccountTypeModel AccountType { get; set; } = default!;
    public ICollection<TransactionModel> Transactions { get; set; } = [];

    public bool Equals(AccountModel? other)
    {
        if (other == null)
            return false;
        if (ReferenceEquals(this, other))
            return true;

        return Id == other.Id;
    }
    public override int GetHashCode() => Id.GetHashCode();
    public override bool Equals(object? obj) => Equals(obj as AccountModel);

    public static bool operator ==(AccountModel? left, AccountModel? right) => EqualityComparer<AccountModel>.Default.Equals(left, right);

    public static bool operator !=(AccountModel? left, AccountModel? right) => !(left == right);
}
