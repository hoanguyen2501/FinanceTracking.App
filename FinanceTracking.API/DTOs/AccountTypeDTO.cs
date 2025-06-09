namespace FinanceTracking.API.DTOs;

public sealed class AccountTypeDTO
{
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public ICollection<AccountDTO> Accounts { get; set; } = [];
}

public sealed class CreateAccountTypeDTO
{
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
}

public sealed class UpdateAccountTypeDTO
{
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
}