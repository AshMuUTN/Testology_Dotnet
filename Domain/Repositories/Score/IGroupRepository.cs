using System.Collections.Generic;
using System.Threading.Tasks;
using Testology_Dotnet.Domain.Models.Score;

namespace Testology_Dotnet.Domain.Repositories.Score
{
    public interface IGroupRepository
    {
        Task<IEnumerable<Group>> ListAsync(int subtestId);
        void Add(Group group);
        void Update(Group group);
        Task Delete(int groupId);
    }
}