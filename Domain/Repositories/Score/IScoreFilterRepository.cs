using System.Collections.Generic;
using System.Threading.Tasks;
using Testology_Dotnet.Domain.Models.Score;

namespace Testology_Dotnet.Domain.Repositories.Score
{
    public interface IScoreFilterRepository
    {
        Task<IEnumerable<ScoreFilter>> ListAsync();
    }
}