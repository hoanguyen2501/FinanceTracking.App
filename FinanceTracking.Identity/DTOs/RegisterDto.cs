using System.ComponentModel.DataAnnotations;

namespace FinanceTracking.Identity.DTOs
{
    public sealed class RegisterDto
    {
        [Required]
        public string Username { get; set; } = default!;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = default!;

        [Required]
        [MinLength(6)]
        public string Password { get; set; } = default!;
    }
}