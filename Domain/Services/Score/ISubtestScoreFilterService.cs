using System.Collections.Generic;
using System.Threading.Tasks;
using Testology_Dotnet.Domain.Models.Score;
using Testology_Dotnet.Domain.Services.Communication;
using Testology_Dotnet.Domain.Services.Communication.Score;

namespace Testology_Dotnet.Domain.Services.Score
{
    public interface ISubtestScoreFilterService
    {
        Task<IEnumerable<SubtestScoreFilter>> ListAsync();
        Task<CreateSubtestScoreFilterResponse> CreateOrUpdateSubtestScoreFilterAsync(SubtestScoreFilter subtestScoreFilter);
        Task<MessageResponse> DeleteSubtestScoreFilterAsync(int subtestScoreFilterId);
    }
}