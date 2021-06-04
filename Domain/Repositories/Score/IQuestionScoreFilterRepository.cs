using System.Collections.Generic;
using System.Threading.Tasks;
using Testology_Dotnet.Domain.Models.Score;

namespace Testology_Dotnet.Domain.Repositories.Score
{
    public interface IQuestionScoreFilterRepository
    {
        Task<IEnumerable<QuestionScoreFilter>> ListAsync();
        void Add(QuestionScoreFilter questionScoreFilter);
        void Update(QuestionScoreFilter questionScoreFilter);
        Task Delete(int questionScoreFilterId);
    }
}