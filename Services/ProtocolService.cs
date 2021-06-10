using System.Collections.Generic;
using System.Threading.Tasks;
using Testology_Dotnet.Domain.Models;
using Testology_Dotnet.Domain.Repositories;
using Testology_Dotnet.Domain.Services;
using Testology_Dotnet.Domain.Services.Communication;

namespace Testology_Dotnet.Services
{
    public class ProtocolService : IProtocolService
    {
        private readonly IProtocolRepository _protocolRepository;
        private readonly IUnitOfWork _unitOfWork;
        public ProtocolService(IProtocolRepository protocolRepository, IUnitOfWork unitOfWork)
        {
            _protocolRepository = protocolRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<CreateProtocolResponse> CreateOrUpdateProtocolAsync(Protocol protocol)
        {
            // TODO :: CHECK IF SUBTEST BELONGS TO TOKEN USER'S TESTS
            //https://stackoverflow.com/questions/46112258/how-do-i-get-current-user-in-net-core-web-api-from-jwt-token
            
            if(protocol.Id == 0){
                _protocolRepository.Add(protocol);
            } else {
                _protocolRepository.Update(protocol);
            }
            await _unitOfWork.CompleteAsync();

            return new CreateProtocolResponse(true, null, protocol);
            
        }

        public async Task<MessageResponse> DeleteProtocolAsync(int protocolId)
        {
            await _protocolRepository.Delete(protocolId);
            await _unitOfWork.CompleteAsync();

            return new MessageResponse(true, "Protocol deleted successfully");
        }

        public async Task<IEnumerable<Protocol>> ListAsync(int testId)
        {
            // TODO :: CHECK IF TEST BELONGS TO TOKEN USER 
            //https://stackoverflow.com/questions/46112258/how-do-i-get-current-user-in-net-core-web-api-from-jwt-token
            return await _protocolRepository.ListAsync(testId);
        }
    }
}