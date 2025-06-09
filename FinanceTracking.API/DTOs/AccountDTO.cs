namespace FinanceTracking.API.DTOs;

public sealed class AccountDTO
{
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public string AccountTypeId { get; set; } = default!;
    public AccountTypeDTO AccountType { get; set; } = default!;
}

public sealed class CreateAccountDTO
{
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public string AccountTypeId { get; set; } = default!;
    public AccountTypeDTO AccountType { get; set; } = default!;
}

public sealed class UpdateAccountDTO
{
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public string AccountTypeId { get; set; } = default!;
    public AccountTypeDTO AccountType { get; set; } = default!;
}