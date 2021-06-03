using Testology_Dotnet.Domain.Models;

namespace Testology_Dotnet.Domain.Services.Communication
{
    public class CreateImageResponse : BaseResponse
    {
        public Image Image { get; private set; }

        public CreateImageResponse(bool success, string message, Image question) : base(success, message)
        {
            Image = question;
        }
    }
}