using System.Collections.Generic;
using System.Threading.Tasks;
using Testology_Dotnet.Domain.Models.Score;

namespace Testology_Dotnet.Domain.Repositories.Score
{
    public interface IGroupScoreFilterRepository
    {
        Task<IEnumerable<GroupScoreFilter>> ListAsync();
        void Add(GroupScoreFilter groupScoreFilter);
        void Update(GroupScoreFilter groupScoreFilter);
        Task Delete(int groupScoreFilterId);
    }
}