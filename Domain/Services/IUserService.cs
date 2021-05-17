using System.Threading.Tasks;
using Testology_Dotnet.Domain.Models.Auth;
using Testology_Dotnet.Domain.Services.Communication;

namespace Testology_Dotnet.Domain.Services
{
    public interface IUserService
    {
         Task<CreateUserResponse> CreateUserAsync(User user, params ApplicationRole[] userRoles);
         Task<CreateUserResponse> UpdateUserPasswordAsync(User user);
         Task<User> FindByEmailAsync(string email);
    }
}