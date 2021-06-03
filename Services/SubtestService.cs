using System.Collections.Generic;
using System.Threading.Tasks;
using Testology_Dotnet.Domain.Models;
using Testology_Dotnet.Domain.Services;
using Testology_Dotnet.Domain.Repositories;
using Testology_Dotnet.Domain.Services.Communication;
using Testology_Dotnet.Domain.Repositories.Auth;

namespace Testology_Dotnet.Services
{
    public class SubtestService : ISubtestService
    {
        private readonly ISubtestRepository _subtestRepository;
        private readonly IUnitOfWork _unitOfWork;
        public SubtestService(ISubtestRepository subtestRepository, IUnitOfWork unitOfWork)
        {
            _subtestRepository = subtestRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Subtest>> ListAsync(int testId)
        {
            // TODO :: CHECK IF TEST BELONGS TO TOKEN USER 
            //https://stackoverflow.com/questions/46112258/how-do-i-get-current-user-in-net-core-web-api-from-jwt-token
            return await _subtestRepository.ListAsync(testId);
        }

        public async Task<CreateSubtestResponse> CreateOrUpdateSubtestAsync(Subtest subtest)
        {
            // TODO :: CHECK IF SUBTEST BELONGS TO TOKEN USER'S TESTS
            //https://stackoverflow.com/questions/46112258/how-do-i-get-current-user-in-net-core-web-api-from-jwt-token
            
            if(subtest.Id == 0){
                _subtestRepository.Add(subtest);
            } else {
                _subtestRepository.Update(subtest);
            }
            await _unitOfWork.CompleteAsync();

            return new CreateSubtestResponse(true, null, subtest);
        }

        public async Task<MessageResponse> DeleteSubtestAsync(int subtestId)
        {
            await _subtestRepository.Delete(subtestId);
            await _unitOfWork.CompleteAsync();

            return new MessageResponse(true, "Subtest deleted successfully");
        }
    }
}