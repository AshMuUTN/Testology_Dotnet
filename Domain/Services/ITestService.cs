using System.Collections.Generic;
using System.Threading.Tasks;
using Testology_Dotnet.Domain.Models;
using Testology_Dotnet.Domain.Services.Communication;

namespace Testology_Dotnet.Domain.Services
{
    public interface ITestService
    {
         Task<IEnumerable<Test>> ListAsync(string email);
         Task<CreateTestResponse> CreateOrUpdateTestAsync(Test test, string userEmail);
         Task<MessageResponse> DeleteTestAsync(int testId);
    }
}