using Testology_Dotnet.Domain.Models;

namespace Testology_Dotnet.Domain.Services.Communication
{
    public class CreateTestResponse : BaseResponse
    {
        public Test Test { get; private set; }

        public CreateTestResponse(bool success, string message, Test test) : base(success, message)
        {
            Test = test;
        }
    }
}