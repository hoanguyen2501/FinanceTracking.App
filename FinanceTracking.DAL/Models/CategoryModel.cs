namespace FinanceTracking.DAL.Models
{
    public sealed class CategoryModel : BaseModel
    {
        public enum CategoryType
        {
            Income,
            Expense
        }

        public string Name { get; set; } = default!;
        public string Icon { get; set; } = default!;
        public string? Description { get; set; }
        public CategoryType Type { get; set; } = default!;
    }
}
