using System.Collections.Generic;
using System.Threading.Tasks;
using Testology_Dotnet.Domain.Models.Score;
using Testology_Dotnet.Domain.Services.Communication;
using Testology_Dotnet.Domain.Services.Communication.Score;

namespace Testology_Dotnet.Domain.Services.Score
{
    public interface IGroupScoreFilterService
    {
        Task<IEnumerable<GroupScoreFilter>> ListAsync(int subtestId);
        Task<CreateGroupScoreFilterResponse> CreateOrUpdateGroupScoreFilterAsync(GroupScoreFilter groupScoreFilter);
        Task<MessageResponse> DeleteGroupScoreFilterAsync(int groupScoreFilterId);
    }
}