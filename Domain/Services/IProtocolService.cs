using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Testology_Dotnet.Domain.Models;
using Testology_Dotnet.Domain.Services.Communication;

namespace Testology_Dotnet.Domain.Services
{
    public interface IProtocolService
    {
         Task<IEnumerable<Protocol>> ListAsync(int testId);
         Task<CreateProtocolResponse> CreateOrUpdateProtocolAsync(Protocol protocol);
         Task<MessageResponse> DeleteProtocolAsync(int protocolId);
    }
}