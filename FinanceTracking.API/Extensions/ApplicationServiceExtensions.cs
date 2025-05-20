using FinanceTracking.API.Core;
using FinanceTracking.BLL.Extensions;
using FinanceTracking.DAL.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracking.API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection service, IHostEnvironment env, IConfiguration configuration)
        {
            service.AddRouting(options =>
            {
                options.LowercaseUrls = true;
            });

            service.AddDbContext<FinanceTrackingDbContext>((sp, options) => options
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

            service.AddAutoMapper(typeof(DefaultMapperProfile));

            service.AddBLLDependencyInjections();

            return service;
        }
    }
}
