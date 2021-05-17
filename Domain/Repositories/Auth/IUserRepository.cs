using System.Threading.Tasks;
using Testology_Dotnet.Domain.Models.Auth;

namespace Testology_Dotnet.Domain.Repositories.Auth
{
    public interface IUserRepository
    {
        Task AddAsync(User user, ApplicationRole[] userRoles);
        void UpdatePassword(User user);
        Task<User> FindByEmailAsync(string email);
    }
}