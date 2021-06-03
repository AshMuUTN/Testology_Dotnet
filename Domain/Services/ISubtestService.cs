using System.Collections.Generic;
using System.Threading.Tasks;
using Testology_Dotnet.Domain.Models;
using Testology_Dotnet.Domain.Services.Communication;

namespace Testology_Dotnet.Domain.Services
{
    public interface ISubtestService
    {
         Task<IEnumerable<Subtest>> ListAsync(int testId);
         Task<CreateSubtestResponse> CreateOrUpdateSubtestAsync(Subtest subtest);
         Task<MessageResponse> DeleteSubtestAsync(int subtestId);
    }
}