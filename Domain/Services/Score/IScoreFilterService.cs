using System.Collections.Generic;
using System.Threading.Tasks;
using Testology_Dotnet.Domain.Models.Score;

namespace Testology_Dotnet.Domain.Services.Score
{
    public interface IScoreFilterService
    {
        Task<IEnumerable<ScoreFilter>> ListAsync();
    }
}