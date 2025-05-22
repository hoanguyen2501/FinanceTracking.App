using Newtonsoft.Json;

namespace FinanceTracking.DAL.Models
{
    public abstract class BaseModel
    {
        public string Id { get; set; } = default!;

        public virtual string? ToString(bool detail, bool pretty = false)
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
            return ToString();
        }
    }
}
