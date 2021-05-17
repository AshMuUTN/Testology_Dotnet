using System.Threading.Tasks;
using Testology_Dotnet.Domain.Services.Communication;

namespace Testology_Dotnet.Domain.Services
{
    public interface IAuthenticationService
    {
         Task<TokenResponse> CreateAccessTokenAsync(string email, string password);
         Task<TokenResponse> RefreshTokenAsync(string refreshToken, string userEmail);
         void RevokeRefreshToken(string refreshToken);
    }
}