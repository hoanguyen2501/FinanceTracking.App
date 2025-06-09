using FinanceTracking.BLL.Interfaces;
using FinanceTracking.BLL.Services;
using FinanceTracking.DAL.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace FinanceTracking.BLL.Extensions
{
    public static class DependencyInjections
    {
        public static IServiceCollection AddBLLDependencyInjections(this IServiceCollection services)
        {
            services.AddDALDependencyInjections();

            services.AddServices();

            return services;
        }

        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IAccountTypeService, AccountTypeService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IMemberService, MemberService>();
            services.AddScoped<ITransactionService, TransactionService>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
