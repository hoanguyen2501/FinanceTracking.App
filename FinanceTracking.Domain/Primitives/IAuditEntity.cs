namespace FinanceTracking.Domain.Primitives
{
    public interface IAuditEntity
    {
        string? CreatedBy { get; set; }
        DateTimeOffset CreatedAt { get; set; }
        string? UpdatedBy { get; set; }
        DateTimeOffset UpdatedAt { get; set; }
    }
}
