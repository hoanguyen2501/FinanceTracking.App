using Microsoft.AspNetCore.Identity;

namespace FinanceTracking.Identity.Services
{
    public interface ITokenService
    {
        string CreateToken(IdentityUser user);
    }
}