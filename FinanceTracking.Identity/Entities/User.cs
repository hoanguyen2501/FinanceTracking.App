using Microsoft.AspNetCore.Identity;

namespace FinanceTracking.Identity.Entities
{
    public sealed class User : IdentityUser
    {
        public string? Initials { get; set; }
    }
}