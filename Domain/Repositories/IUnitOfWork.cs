using System.Threading.Tasks;

namespace Testology_Dotnet.Domain.Repositories
{
    public interface IUnitOfWork
    {
         Task CompleteAsync();
    }
}