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
    public class GroupService : IGroupService
    {

        private readonly IGroupRepository _groupRepository;
        private readonly IUnitOfWork _unitOfWork;
        public GroupService(IGroupRepository groupRepository, IUnitOfWork unitOfWork)
        {
            _groupRepository = groupRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<CreateGroupResponse> CreateOrUpdateGroupAsync(Group group)
        {
            // TODO :: CHECK IF GROUP SCORE FILTER BELONGS TO TOKEN USER 
            //https://stackoverflow.com/questions/46112258/how-do-i-get-current-user-in-net-core-web-api-from-jwt-token
            
            if(group.Id == 0){
                _groupRepository.Add(group);
            } else {
                _groupRepository.Update(group);
            }
            await _unitOfWork.CompleteAsync();

            return new CreateGroupResponse(true, null, group);
        }

        public async Task<MessageResponse> DeleteGroupAsync(int groupId)
        {
            await _groupRepository.Delete(groupId);
            await _unitOfWork.CompleteAsync();

            return new MessageResponse(true, "Group deleted successfully");
        }

        public async Task<IEnumerable<Group>> ListAsync(int subtestId)
        {
            // TODO :: CHECK IF USER IS TOKEN USER 
            //https://stackoverflow.com/questions/46112258/how-do-i-get-current-user-in-net-core-web-api-from-jwt-token
            return await _groupRepository.ListAsync(subtestId);
        }
    }
}