using FinanceTracking.DAL.DataAccess;
using FinanceTracking.DAL.Entities;
using Newtonsoft.Json;

namespace FinanceTracking.API.Data;

public static class DataSeeding
{
    public static void SeedMasterData(IServiceProvider provider)
    {
        FinanceTrackingDbContext context = provider.GetRequiredService<FinanceTrackingDbContext>();

        // Account Types & Accounts
        {
            var jsonData = File.ReadAllText("Data/account-types.json");
            var accountTypes = JsonConvert.DeserializeObject<IEnumerable<AccountTypeEntity>>(jsonData) ?? throw new Exception("Seed Account Type data is missing");
            if (!context.AccountTypes.Any())
            {
                context.AddRange(accountTypes);
                context.SaveChanges();
            }
        }

        // Categories
        {
            var jsonData = File.ReadAllText("Data/categories.json");
            var categories = JsonConvert.DeserializeObject<IEnumerable<CategoryEntity>>(jsonData) ?? throw new Exception("Seed Category data is missing");
            if (!context.Categories.Any())
            {
                context.AddRange(categories);
                context.SaveChanges();
            }
        }

        // Members
        {
            var jsonData = File.ReadAllText("Data/members.json");
            var members = JsonConvert.DeserializeObject<IEnumerable<MemberEntity>>(jsonData) ?? throw new Exception("Seed Category data is missing");
            if (!context.Members.Any())
            {
                context.AddRange(members);
                context.SaveChanges();
            }
        }
    }
}
