namespace FinanceTracking.DAL.Entities
{
    public sealed class CategoryEntity : BaseEntity
    {
        public const string IncomeType = "I";
        public const string ExpenseType = "X";

        public string Name { get; set; } = default!;
        public string Icon { get; set; } = default!;
        public string? Description { get; set; }
        public string Type { get; set; } = default!;
        public ICollection<TransactionEntity> Transactions { get; set; } = [];
    }
}
