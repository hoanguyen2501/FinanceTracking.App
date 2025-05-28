using System.Text;
using FinanceTracking.Identity.Data;
using FinanceTracking.Identity.Entities;
using FinanceTracking.Identity.Helpers;
using FinanceTracking.Identity.Services;
using FinanceTracking.Identity.Services.Implementations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace FinanceTracking.Identity.Extensions
{
    public static class AppIdentityExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppIdentityDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            services.AddAuthentication(configuration);

            return services;
        }

        private static IServiceCollection AddAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

            JwtSettings jwtSettings = configuration.GetSection("JwtSettings").Get<JwtSettings>() ?? throw new Exception("JwtSettings is missing");

            services.AddAuthorization();
            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtSettings.Issuer,
                        ValidAudience = jwtSettings.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret))
                    };
                });

            services.AddIdentityCore<User>()
                .AddEntityFrameworkStores<AppIdentityDbContext>()
                .AddApiEndpoints()
                .AddDefaultTokenProviders();

            services.AddScoped<ITokenService, TokenService>();

            return services;
        }
    }
}
