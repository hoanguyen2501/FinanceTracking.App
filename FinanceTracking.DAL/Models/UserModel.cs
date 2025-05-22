namespace FinanceTracking.DAL.Models
{
    public sealed class UserModel : BaseModel
    {
        public string FirstName { get; set; } = default!;
        public string? LastName { get; set; }
        public string Email { get; set; } = default!;
        public string Username { get; set; } = default!;
        public string PasswordHash { get; set; } = default!;
        public bool IsActive { get; set; } = default!;
        public ICollection<TransactionModel> Transactions { get; set; } = [];
    }
}
