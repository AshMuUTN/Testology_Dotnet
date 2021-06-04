using System.Collections.Generic;
using System.Threading.Tasks;
using Testology_Dotnet.Domain.Models.Score;

namespace Testology_Dotnet.Domain.Repositories.Score
{
    public interface ISubtestScoreFilterRepository
    {
        Task<IEnumerable<SubtestScoreFilter>> ListAsync();
        void Add(SubtestScoreFilter subtestScoreFilter);
        void Update(SubtestScoreFilter subtestScoreFilter);
        Task Delete(int subtestScoreFilterId);
    }
}