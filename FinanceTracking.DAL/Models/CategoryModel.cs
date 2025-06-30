namespace FinanceTracking.DAL.Models;

public enum CategoryType
{
    Income,
    Expense
}

public sealed class CategoryModel : BaseModel, IEquatable<CategoryModel>
{
    public string Name { get; set; } = default!;
    public string Icon { get; set; } = default!;
    public string? Description { get; set; }
    public CategoryType Type { get; set; } = default!;

    public bool Equals(CategoryModel? other)
    {
        if (other == null)
            return false;
        if (ReferenceEquals(this, other))
            return true;

        return Id == other.Id;
    }
    public override int GetHashCode() => Id.GetHashCode();
    public override bool Equals(object? obj) => Equals(obj as CategoryModel);

    public static bool operator ==(CategoryModel? left, CategoryModel? right) => EqualityComparer<CategoryModel>.Default.Equals(left, right);

    public static bool operator !=(CategoryModel? left, CategoryModel? right) => !(left == right);
}
