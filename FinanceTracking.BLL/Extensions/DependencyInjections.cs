using FinanceTracking.BLL.Interfaces;
using FinanceTracking.BLL.Services;
using FinanceTracking.DAL.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace FinanceTracking.BLL.Extensions
{
    public static class DependencyInjections
    {
        public static IServiceCollection AddBLLDependencyInjections(this IServiceCollection service)
        {
            service.AddDALDependencyInjections();

            service.AddServices();

            return service;
        }

        private static IServiceCollection AddServices(this IServiceCollection service)
        {
            service.AddScoped<IAccountService, AccountService>();
            service.AddScoped<IAccountTypeService, AccountTypeService>();
            service.AddScoped<ICategoryService, CategoryService>();
            service.AddScoped<IMemberService, MemberService>();
            service.AddScoped<ITransactionService, TransactionService>();
            service.AddScoped<IUserService, UserService>();

            return service;
        }
    }
}
