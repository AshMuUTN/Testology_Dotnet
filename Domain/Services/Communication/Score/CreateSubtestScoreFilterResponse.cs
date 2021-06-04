using Testology_Dotnet.Domain.Models.Score;

namespace Testology_Dotnet.Domain.Services.Communication.Score
{
    public class CreateSubtestScoreFilterResponse : BaseResponse
    {
        public SubtestScoreFilter SubtestScoreFilter { get; private set; }

        public CreateSubtestScoreFilterResponse(bool success, string message, SubtestScoreFilter subtestScoreFilter) : base(success, message)
        {
            SubtestScoreFilter = subtestScoreFilter;
        }
    }
}