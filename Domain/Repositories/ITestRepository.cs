using System.Collections.Generic;
using System.Threading.Tasks;
using Testology_Dotnet.Domain.Models;

namespace Testology_Dotnet.Domain.Repositories
{
    public interface ITestRepository
    {
         Task<IEnumerable<Test>> ListAsync(int UserId);
         void Add(Test test);

         void Update(Test test);
         Task Delete(int testId);
    }
}