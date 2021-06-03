using System.Collections.Generic;
using System.Threading.Tasks;
using Testology_Dotnet.Domain.Models;

namespace Testology_Dotnet.Domain.Repositories
{
    public interface ISubtestRepository
    {
         Task<IEnumerable<Subtest>> ListAsync(int testId);
         void Add(Subtest subtest);

         void Update(Subtest subtest);
         Task Delete(int subtestId);
    }
}