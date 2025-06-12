namespace FinanceTracking.API.DTOs;

public sealed class UserDTO
{
    public string Id { get; set; } = default!;
    public string FirstName { get; set; } = default!;
    public string? LastName { get; set; }
    public string Email { get; set; } = default!;
    public string Username { get; set; } = default!;
    public string Status { get; set; } = default!;
}