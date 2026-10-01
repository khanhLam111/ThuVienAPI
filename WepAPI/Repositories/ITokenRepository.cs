using Microsoft.AspNetCore.Identity;

namespace WepAPI.Repositories
{
    public interface ITokenRepository
    {
        string CreateJWTToken(IdentityUser user, List<string> roles);
    }
}