using System.Text;
using AutoMapper;
using AutoMapper.EquivalencyExpression;
using FinanceTracking.API.Helpers;
using FinanceTracking.API.Interceptor;
using FinanceTracking.API.Mappers;
using FinanceTracking.BLL.Extensions;
using FinanceTracking.DAL.DataAccess;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace FinanceTracking.API.Extensions;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IHostEnvironment env, IConfiguration configuration)
    {
        services.AddRouting(options =>
        {
            options.LowercaseUrls = true;
        });

        services.AddDbContext<FinanceTrackingDbContext>((sp, options) => options
            .UseNpgsql(
                configuration.GetConnectionString("DefaultConnection") ?? throw new Exception("Doesn't have config for DefaultConnection"),
                b => b.MigrationsAssembly("FinanceTracking.DAL")
                    .EnableRetryOnFailure(10)
                    .UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)
            )
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors()
            .EnableServiceProviderCaching()
            .AddInterceptors(sp.GetRequiredService<AuditInterceptor>())
        );

        services.AddAutoMapper(cfg =>
        {
            services.AddMapperProfiles(cfg);
        }, typeof(Program).Assembly);
        services.AddBLLDependencyInjections();
        services.AddAuthentication(configuration);

        services.AddScoped<AuditInterceptor>();

        return services;
    }

    private static IServiceCollection AddAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
        services.AddSingleton(sp => sp.GetRequiredService<IOptions<JwtSettings>>().Value);
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme =
            options.DefaultChallengeScheme =
            options.DefaultForbidScheme =
            options.DefaultScheme =
            options.DefaultSignInScheme =
            options.DefaultSignOutScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            JwtSettings jwtSettings = configuration.GetSection("JwtSettings").Get<JwtSettings>()
                ?? throw new Exception($"{nameof(JwtSettings)} configuration is missing.");
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = jwtSettings.Issuer,
                ValidateAudience = true,
                ValidAudience = jwtSettings.Audience,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SigningKey)),
            };
        });

        services.AddAuthorization();

        return services;
    }

    private static IServiceCollection AddMapperProfiles(this IServiceCollection services, IMapperConfigurationExpression cfg)
    {
        cfg.AddCollectionMappers();
        cfg.AddProfile<AccountMapperProfile>();
        cfg.AddProfile<AccountTypeMapperProfile>();
        cfg.AddProfile<CategoryMapperProfile>();
        cfg.AddProfile<MemberMapperProfile>();
        cfg.AddProfile<UserMapperProfile>();

        return services;
    }
}
