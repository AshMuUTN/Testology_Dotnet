using Testology_Dotnet.Domain.Models.Auth;

namespace Testology_Dotnet.Domain.Security.Tokens
{
    public interface ITokenHandler
    {
         AccessToken CreateAccessToken(User user);
         string CreatePasswordResetToken(User user);
         RefreshToken TakeRefreshToken(string token);
         void RevokeRefreshToken(string token);
    }
}