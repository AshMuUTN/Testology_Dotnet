using Testology_Dotnet.Domain.Models;

namespace Testology_Dotnet.Domain.Services.Communication
{
    public class CreateAnswerResponse : BaseResponse
    {
        public Answer Answer { get; private set; }
        public CreateAnswerResponse(bool success, string message, Answer answer) : base(success, message)
        {
            Answer = answer;
        }
    }
}