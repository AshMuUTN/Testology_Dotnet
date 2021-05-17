using SendGrid;
using System.Threading.Tasks;

namespace Testology_Dotnet.Domain.Services
{
    public interface IPasswordRecoveryEmailService
    {
        Task<Response> Execute(string Email);
    }
}