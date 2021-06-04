using Testology_Dotnet.Domain.Models.Score;

namespace Testology_Dotnet.Domain.Services.Communication.Score
{
    public class CreateGroupResponse : BaseResponse
    {
        public Group Group { get; private set; }

        public CreateGroupResponse(bool success, string message, Group group) : base(success, message)
        {
            Group = group;
        }
    }
}