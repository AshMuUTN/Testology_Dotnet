using Testology_Dotnet.Domain.Models;

namespace Testology_Dotnet.Domain.Services.Communication
{
    public class CreateProtocolResponse : BaseResponse
    {
        public Protocol Protocol { get; private set; }
        public CreateProtocolResponse(bool success, string message, Protocol protocol) : base(success, message)
        {
            Protocol = protocol;
        }
    }
}