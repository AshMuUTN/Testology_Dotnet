using Testology_Dotnet.Domain.Security.Tokens;

namespace Testology_Dotnet.Domain.Services.Communication
{
    public class TokenResponse : BaseResponse
    {
        public AccessToken Token { get; set; }

        public TokenResponse(bool success, string message, AccessToken token) : base(success, message)
        {
            Token = token;
        }
    }
}