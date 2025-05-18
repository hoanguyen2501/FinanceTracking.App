using FinanceTracking.DAL.DataAccess;

using Microsoft.EntityFrameworkCore;

namespace FinanceTracking.API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection @this, IHostEnvironment env, IConfiguration configuration)
        {
            @this.AddDbContext<FinanceTrackingDbContext>((sp, options) => options
                .UseNpgsql(
                    configuration.GetConnectionString("DefaultConnection") ?? throw new Exception("Doesn't have config for DefaultConnection"),
                    b => b.MigrationsAssembly("FinanceTracking.DAL")
                        .EnableRetryOnFailure(10)
                        .UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)
                )
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors()
                .EnableServiceProviderCaching()
            );
            return @this;
        }
    }
}
