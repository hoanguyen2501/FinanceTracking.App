using FinanceTracking.Infrastructure.Interfaces;
using FinanceTracking.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace FinanceTracking.Infrastructure.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection @this)
        {
            @this.AddScoped<ICategoryRepository, CategoryRepository>();
            return @this;
        }
    }
}
