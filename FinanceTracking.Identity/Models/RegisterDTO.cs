namespace FinanceTracking.Identity.Models
{
    public sealed class RegisterDTO
    {
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
}