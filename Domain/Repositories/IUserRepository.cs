using System.Collections.Generic;
using System.Threading.Tasks;
using Testology_Dotnet.Domain.Models;

namespace Testology_Dotnet.Domain.Repositories
{
    public interface IUserRepository
    {
         Task<IEnumerable<User>> ListAsync();
    }
}