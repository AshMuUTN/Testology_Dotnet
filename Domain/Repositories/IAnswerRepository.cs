using System.Threading.Tasks;
using Testology_Dotnet.Domain.Models;

namespace Testology_Dotnet.Domain.Repositories
{
    public interface IAnswerRepository
    {
         void Add(Answer answer);
         void Update(Answer answer);
         Task Delete(int answerId);
    }
}