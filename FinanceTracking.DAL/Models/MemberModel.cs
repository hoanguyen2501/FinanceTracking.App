namespace FinanceTracking.DAL.Models;


public enum MemberStatus
{
    Active,
    Inactive
}
public sealed class MemberModel : BaseModel, IEquatable<MemberModel>
{
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public MemberStatus Status { get; set; } = default!;
    public ICollection<TransactionModel> Transactions { get; set; } = [];

    public bool Equals(MemberModel? other)
    {
        if (other == null)
            return false;
        if (ReferenceEquals(this, other))
            return true;

        return Id == other.Id;
    }
    public override int GetHashCode() => Id.GetHashCode();
    public override bool Equals(object? obj) => Equals(obj as MemberModel);

    public static bool operator ==(MemberModel? left, MemberModel? right) => EqualityComparer<MemberModel>.Default.Equals(left, right);

    public static bool operator !=(MemberModel? left, MemberModel? right) => !(left == right);
}
