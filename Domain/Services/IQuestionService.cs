using System.Collections.Generic;
using System.Threading.Tasks;
using Testology_Dotnet.Domain.Models;
using Testology_Dotnet.Domain.Services.Communication;

namespace Testology_Dotnet.Domain.Services
{
    public interface IQuestionService
    {
         Task<IEnumerable<Question>> ListAsync(int subtestId);
         Task<CreateQuestionResponse> CreateOrUpdateQuestionAsync(Question question);
         Task<MessageResponse> DeleteQuestionAsync(int questionId);
    }
}