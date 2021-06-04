using System.Collections.Generic;
using System.Threading.Tasks;
using Testology_Dotnet.Domain.Models.Score;
using Testology_Dotnet.Domain.Services.Communication;
using Testology_Dotnet.Domain.Services.Communication.Score;

namespace Testology_Dotnet.Domain.Services.Score
{
    public interface IGroupService
    {
        Task<IEnumerable<Group>> ListAsync();
        Task<CreateGroupResponse> CreateOrUpdateGroupAsync(Group group);
        Task<MessageResponse> DeleteGroupAsync(int groupId);
    }
}