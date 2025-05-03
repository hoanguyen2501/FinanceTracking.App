using FinanceTracking.Domain.Configurations;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracking.Domain.Extensions
{
    public static class EntityExtensions
    {
        public static ModelBuilder AddEntityConfigurations(this ModelBuilder @this)
        {
            @this.ApplyConfigurationsFromAssembly(typeof(AccountEntityConfiguration).Assembly);
            @this.ApplyConfigurationsFromAssembly(typeof(AccountTypeEntityConfiguration).Assembly);
            @this.ApplyConfigurationsFromAssembly(typeof(CategoryEntityConfiguration).Assembly);
            @this.ApplyConfigurationsFromAssembly(typeof(MemberEntityConfiguration).Assembly);
            @this.ApplyConfigurationsFromAssembly(typeof(TransactionEntityConfiguration).Assembly);
            @this.ApplyConfigurationsFromAssembly(typeof(UserEntityConfiguration).Assembly);
            return @this;
        }
    }
}
