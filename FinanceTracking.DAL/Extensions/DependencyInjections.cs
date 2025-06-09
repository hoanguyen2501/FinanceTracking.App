using FinanceTracking.DAL.Interfaces;
using FinanceTracking.DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace FinanceTracking.DAL.Extensions
{
    public static class DependencyInjections
    {
        public static IServiceCollection AddDALDependencyInjections(this IServiceCollection services)
        {
            services.AddRepositories();

            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IAccountTypeRepository, AccountTypeRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IMemberRepository, MemberRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
