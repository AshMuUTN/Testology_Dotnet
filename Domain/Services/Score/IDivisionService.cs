using System.Collections.Generic;
using System.Threading.Tasks;
using Testology_Dotnet.Domain.Models.Score;
using Testology_Dotnet.Domain.Services.Communication;
using Testology_Dotnet.Domain.Services.Communication.Score;

namespace Testology_Dotnet.Domain.Services.Score
{
    public interface IDivisionService
    {
        Task<IEnumerable<Division>> ListAsync(int subtestId);
        Task<CreateDivisionResponse> CreateOrUpdateDivisionAsync(Division division);
        Task<MessageResponse> DeleteDivisionAsync(int divisionId);
    }
}