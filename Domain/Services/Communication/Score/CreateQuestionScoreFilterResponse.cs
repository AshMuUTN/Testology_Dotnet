using Testology_Dotnet.Domain.Models.Score;

namespace Testology_Dotnet.Domain.Services.Communication.Score
{
    public class CreateQuestionScoreFilterResponse : BaseResponse
    {
        public QuestionScoreFilter QuestionScoreFilter { get; private set; }

        public CreateQuestionScoreFilterResponse(bool success, string message, QuestionScoreFilter questionScoreFilter) : base(success, message)
        {
            QuestionScoreFilter = questionScoreFilter;
        }
    }
}