using System.Collections.Generic;
using System.Threading.Tasks;
using Testology_Dotnet.Domain.Models;

namespace Testology_Dotnet.Domain.Repositories
{
    public interface IQuestionRepository
    {
         Task<IEnumerable<Question>> ListAsync(int subtestId);
         void Add(Question question);
         void Update(Question question);
         Task Delete(int questionId);
    }
}