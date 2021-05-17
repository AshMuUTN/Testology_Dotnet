using System.Collections.Generic;
using System.Threading.Tasks;
using Testology_Dotnet.Domain.Models;

namespace Testology_Dotnet.Domain.Services
{
    public interface ITestService
    {
         Task<IEnumerable<Test>> ListAsync();
    }
}