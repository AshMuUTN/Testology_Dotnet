using System.Collections.Generic;
using System.Threading.Tasks;
using Testology_Dotnet.Domain.Models.Score;
using Testology_Dotnet.Domain.Repositories;
using Testology_Dotnet.Domain.Repositories.Score;
using Testology_Dotnet.Domain.Services.Communication;
using Testology_Dotnet.Domain.Services.Communication.Score;
using Testology_Dotnet.Domain.Services.Score;

namespace Testology_Dotnet.Services.Score
{
    public class SubtestScoreFilterService : ISubtestScoreFilterService
    {
        private readonly ISubtestScoreFilterRepository _subtestScoreFilterRepository;
        private readonly IUnitOfWork _unitOfWork;
        public SubtestScoreFilterService(ISubtestScoreFilterRepository subtestScoreFilterRepository, IUnitOfWork unitOfWork)
        {
            _subtestScoreFilterRepository = subtestScoreFilterRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<CreateSubtestScoreFilterResponse> CreateOrUpdateSubtestScoreFilterAsync(SubtestScoreFilter subtestScoreFilter)
        {
            // TODO :: CHECK IF GROUP SCORE FILTER BELONGS TO TOKEN USER 
            //https://stackoverflow.com/questions/46112258/how-do-i-get-current-user-in-net-core-web-api-from-jwt-token
            
            if(subtestScoreFilter.Id == 0){
                _subtestScoreFilterRepository.Add(subtestScoreFilter);
            } else {
                _subtestScoreFilterRepository.Update(subtestScoreFilter);
            }
            await _unitOfWork.CompleteAsync();

            return new CreateSubtestScoreFilterResponse(true, null, subtestScoreFilter);
        }

        public async Task<MessageResponse> DeleteSubtestScoreFilterAsync(int subtestScoreFilterId)
        {
            await _subtestScoreFilterRepository.Delete(subtestScoreFilterId);
            await _unitOfWork.CompleteAsync();

            return new MessageResponse(true, "Subtest Score Filter deleted successfully");
        }

        public async Task<IEnumerable<SubtestScoreFilter>> ListAsync()
        {
            // TODO :: CHECK IF USER IS TOKEN USER 
            //https://stackoverflow.com/questions/46112258/how-do-i-get-current-user-in-net-core-web-api-from-jwt-token
            return await _subtestScoreFilterRepository.ListAsync();
        }
    }
}