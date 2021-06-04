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
    public class GroupScoreFilterService : IGroupScoreFilterService
    {
        private readonly IGroupScoreFilterRepository _groupScoreFilterRepository;
        private readonly IUnitOfWork _unitOfWork;

        public GroupScoreFilterService(IGroupScoreFilterRepository groupScoreFilterRepository, IUnitOfWork unitOfWork)
        {
            _groupScoreFilterRepository = groupScoreFilterRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<CreateGroupScoreFilterResponse> CreateOrUpdateGroupScoreFilterAsync(GroupScoreFilter groupScoreFilter)
        {
            // TODO :: CHECK IF GROUP SCORE FILTER BELONGS TO TOKEN USER 
            //https://stackoverflow.com/questions/46112258/how-do-i-get-current-user-in-net-core-web-api-from-jwt-token
            
            if(groupScoreFilter.Id == 0){
                _groupScoreFilterRepository.Add(groupScoreFilter);
            } else {
                _groupScoreFilterRepository.Update(groupScoreFilter);
            }
            await _unitOfWork.CompleteAsync();

            return new CreateGroupScoreFilterResponse(true, null, groupScoreFilter);
        }

        public async Task<MessageResponse> DeleteGroupScoreFilterAsync(int groupScoreFilterId)
        {
            await _groupScoreFilterRepository.Delete(groupScoreFilterId);
            await _unitOfWork.CompleteAsync();

            return new MessageResponse(true, "Group Score Filter deleted successfully");
        }

        public async Task<IEnumerable<GroupScoreFilter>> ListAsync()
        {
            // TODO :: CHECK IF Group score filter  BELONGS TO TOKEN USER 
            //https://stackoverflow.com/questions/46112258/how-do-i-get-current-user-in-net-core-web-api-from-jwt-token
            return await _groupScoreFilterRepository.ListAsync();
        }
    }
}