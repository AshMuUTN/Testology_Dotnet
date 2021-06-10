using System.Collections.Generic;
using System.Threading.Tasks;
using Testology_Dotnet.Domain.Models.Score;

namespace Testology_Dotnet.Domain.Repositories.Score
{
    public interface IDivisionRepository
    {
        Task<IEnumerable<Division>> ListAsync(int subtestId);
        void Add(Division division);
        void Update(Division division);
        Task Delete(int divisionId);
    }
}