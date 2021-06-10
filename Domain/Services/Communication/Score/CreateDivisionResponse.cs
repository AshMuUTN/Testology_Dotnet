using Testology_Dotnet.Domain.Models.Score;

namespace Testology_Dotnet.Domain.Services.Communication.Score
{
    public class CreateDivisionResponse : BaseResponse
    {
        public Division Division { get; private set; }

        public CreateDivisionResponse(bool success, string message, Division division) : base(success, message)
        {
            Division = division;
        }
    }
}