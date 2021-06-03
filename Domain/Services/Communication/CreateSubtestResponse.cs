using Testology_Dotnet.Domain.Models;

namespace Testology_Dotnet.Domain.Services.Communication
{
    public class CreateSubtestResponse : BaseResponse
    {
        public Subtest Subtest { get; private set; }

        public CreateSubtestResponse(bool success, string message, Subtest subtest) : base(success, message)
        {
            Subtest = subtest;
        }
    }
}