using FinanceTracking.DAL.Interfaces;
using FinanceTracking.DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace FinanceTracking.DAL.Extensions
{
    public static class DependencyInjections
    {
        public static IServiceCollection AddDALDependencyInjections(this IServiceCollection service)
        {
            service.AddRepositories();

            return service;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection service)
        {
            service.AddScoped<IAccountRepository, AccountRepository>();
            service.AddScoped<IAccountTypeRepository, AccountTypeRepository>();
            service.AddScoped<ICategoryRepository, CategoryRepository>();
            service.AddScoped<IMemberRepository, MemberRepository>();
            service.AddScoped<ITransactionRepository, TransactionRepository>();
            service.AddScoped<IUserRepository, UserRepository>();

            return service;
        }
    }
}
