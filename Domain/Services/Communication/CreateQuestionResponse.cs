using Testology_Dotnet.Domain.Models;

namespace Testology_Dotnet.Domain.Services.Communication
{
    public class CreateQuestionResponse : BaseResponse
    {
        public Question Question { get; private set; }

        public CreateQuestionResponse(bool success, string message, Question question) : base(success, message)
        {
            Question = question;
        }
    }
}