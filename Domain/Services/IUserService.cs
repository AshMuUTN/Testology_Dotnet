using System.Collections.Generic;
using System.Threading.Tasks;
using Testology_Dotnet.Domain.Models;

namespace Testology_Dotnet.Domain.Services
{
    public interface IUserService
    {
         Task<IEnumerable<User>> ListAsync();
    }
}