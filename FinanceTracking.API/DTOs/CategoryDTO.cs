namespace FinanceTracking.API.DTOs
{
    public sealed class CategoryDTO
    {
        public string Id { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string Icon { get; set; } = default!;
        public string? Description { get; set; }
        public string Type { get; set; } = default!;
    }

    public sealed class CreateCategoryDTO
    {
        public string Name { get; set; } = default!;
        public string Icon { get; set; } = "123";
        public string? Description { get; set; }
        public string Type { get; set; } = "I";
    }
}
