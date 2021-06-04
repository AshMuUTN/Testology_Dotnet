using System.Collections.Generic;
using System.Threading.Tasks;
using Testology_Dotnet.Domain.Models.Score;
using Testology_Dotnet.Domain.Services.Communication;
using Testology_Dotnet.Domain.Services.Communication.Score;

namespace Testology_Dotnet.Domain.Services.Score
{
    public interface IQuestionScoreFilterService
    {
        Task<IEnumerable<QuestionScoreFilter>> ListAsync(int questionId);
        Task<CreateQuestionScoreFilterResponse> CreateOrUpdateQuestionScoreFilterAsync(QuestionScoreFilter questionScoreFilter);
        Task<MessageResponse> DeleteQuestionScoreFilterAsync(int questionScoreFilterId);
    }
}