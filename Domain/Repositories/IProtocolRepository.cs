using System.Collections.Generic;
using System.Threading.Tasks;
using Testology_Dotnet.Domain.Models;

namespace Testology_Dotnet.Domain.Repositories
{
    public interface IProtocolRepository
    {
        Task<IEnumerable<Protocol>> ListAsync(int testId);
         void Add(Protocol protocol);

         void Update(Protocol protocol);
         Task Delete(int protocolId);
        
    }
}