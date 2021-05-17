namespace Testology_Dotnet.Domain.Services.Communication
{
    public class MessageResponse : BaseResponse
    {
        public MessageResponse(bool success, string message) : base(success, message){}
        
    }
}