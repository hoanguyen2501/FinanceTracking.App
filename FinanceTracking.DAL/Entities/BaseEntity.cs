using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using FinanceTracking.DAL.Primitives;

namespace FinanceTracking.DAL.Entities
{
    public abstract class BaseEntity : IdEntity<string>, IAuditEntity
    {
        public string? CreatedBy { get; set; }
        public DateTimeOffset CreatedAt { get; set; } = default!;
        public string? UpdatedBy { get; set; }
        public DateTimeOffset UpdatedAt { get; set; } = default!;

        [Column("xmin")]
        [Timestamp]
        [ConcurrencyCheck]
        public uint Xmin { get; set; }
    }
}
