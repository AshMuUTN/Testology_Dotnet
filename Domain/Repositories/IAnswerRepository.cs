using System.Threading.Tasks;
using Testology_Dotnet.Domain.Models;

namespace Testology_Dotnet.Domain.Repositories
{
    public interface IAnswerRepository
    {
         void Add(Answer protocol);
         void Update(Answer protocol);
         Task Delete(int protocolId);
    }
}