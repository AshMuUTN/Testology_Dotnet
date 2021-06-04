using Testology_Dotnet.Domain.Models.Score;

namespace Testology_Dotnet.Domain.Services.Communication.Score
{
    public class CreateGroupScoreFilterResponse : BaseResponse
    {
        public GroupScoreFilter GroupScoreFilter { get; private set; }

        public CreateGroupScoreFilterResponse(bool success, string message, GroupScoreFilter groupScoreFilter) : base(success, message)
        {
            GroupScoreFilter = groupScoreFilter;
        }
    }
}