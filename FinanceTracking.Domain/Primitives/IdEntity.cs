using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace FinanceTracking.Domain.Primitives
{
    public abstract class IdEntity<TKey>
    {
        [Key]
        [MaxLength(36)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual TKey Id { get; protected set; } = default!;

        public virtual string ToString(bool detail, bool pretty = false)
        {
            if (detail)
            {
                return JsonConvert.SerializeObject(this, new JsonSerializerSettings
                {
                    Formatting = pretty ? Formatting.Indented : Formatting.None,
                    DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
            }
            return $"{Id}";
        }

        public override string ToString() => ToString(true, true);
    }
}
