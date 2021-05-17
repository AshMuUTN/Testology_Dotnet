using System.Collections.Generic;
using System.Threading.Tasks;
using Testology_Dotnet.Domain.Models;
using Testology_Dotnet.Domain.Services;
using Testology_Dotnet.Domain.Repositories;

namespace Testology_Dotnet.Services
{
    public class TestService : ITestService
    {
        private readonly ITestRepository _testRepository;

        public TestService(ITestRepository testRepository)
        {
            this._testRepository = testRepository;
        }
        public async Task<IEnumerable<Test>> ListAsync()
        {
            return await _testRepository.ListAsync();
        }
    }
}