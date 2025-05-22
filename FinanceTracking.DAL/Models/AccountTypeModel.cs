namespace FinanceTracking.DAL.Models
{
    public sealed class AccountTypeModel : BaseModel
    {
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public ICollection<AccountModel> Accounts { get; set; } = [];
    }
}
