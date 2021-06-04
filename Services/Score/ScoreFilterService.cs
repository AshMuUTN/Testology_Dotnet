using System.Collections.Generic;
using System.Threading.Tasks;
using Testology_Dotnet.Domain.Models.Score;
using Testology_Dotnet.Domain.Repositories;
using Testology_Dotnet.Domain.Repositories.Score;
using Testology_Dotnet.Domain.Services.Score;

namespace Testology_Dotnet.Services.Score
{
    public class ScoreFilterService : IScoreFilterService
    {
        private readonly IScoreFilterRepository _testRepository;
        private readonly IUnitOfWork _unitOfWork;
        public ScoreFilterService(IScoreFilterRepository testRepository, IUnitOfWork unitOfWork)
        {
            _testRepository = testRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<ScoreFilter>> ListAsync()
        {
            // TODO :: CHECK IF USER IS TOKEN USER 
            //https://stackoverflow.com/questions/46112258/how-do-i-get-current-user-in-net-core-web-api-from-jwt-token
            return await _testRepository.ListAsync();
        }
    }
}