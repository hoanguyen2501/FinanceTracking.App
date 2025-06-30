namespace FinanceTracking.API.DTOs;

public sealed class MemberDTO
{
    public string Id { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public string? Status { get; set; }
}

public sealed class CreateMemberDTO
{
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public string Status { get; set; } = default!;
}

public sealed class UpdateMemberDTO
{
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public string Status { get; set; } = default!;
}
