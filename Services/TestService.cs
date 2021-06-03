using System.Collections.Generic;
using System.Threading.Tasks;
using Testology_Dotnet.Domain.Models;
using Testology_Dotnet.Domain.Services;
using Testology_Dotnet.Domain.Repositories;
using Testology_Dotnet.Domain.Services.Communication;
using Testology_Dotnet.Domain.Repositories.Auth;

namespace Testology_Dotnet.Services
{
    public class TestService : ITestService
    {
        private readonly ITestRepository _testRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        public TestService(ITestRepository testRepository, IUnitOfWork unitOfWork, IUserRepository userRepository)
        {
            _testRepository = testRepository;
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }
        public async Task<IEnumerable<Test>> ListAsync(string email)
        {
            var existingUser = await _userRepository.FindByEmailAsync(email);
            if(existingUser == null)
            {
                return null;
            }
            // TODO :: CHECK IF USER IS TOKEN USER 
            //https://stackoverflow.com/questions/46112258/how-do-i-get-current-user-in-net-core-web-api-from-jwt-token
            return await _testRepository.ListAsync(existingUser.Id);
        }

        public async Task<CreateTestResponse> CreateOrUpdateTestAsync(Test test, string userEmail)
        {
            var existingUser = await _userRepository.FindByEmailAsync(userEmail);
            if(existingUser == null)
            {
                return new CreateTestResponse(false, "Email does not belong to a registered user.", null);
            }
            // TODO :: CHECK IF USER IS TOKEN USER 
            //https://stackoverflow.com/questions/46112258/how-do-i-get-current-user-in-net-core-web-api-from-jwt-token
            test.UserId = existingUser.Id;
            if(test.Id == 0){
                _testRepository.Add(test);
            } else {
                _testRepository.Update(test);
            }
            await _unitOfWork.CompleteAsync();

            return new CreateTestResponse(true, null, test);
        }

        public async Task<MessageResponse> DeleteTestAsync(int testId)
        {
            await _testRepository.Delete(testId);
            await _unitOfWork.CompleteAsync();

            return new MessageResponse(true, "Test deleted successfully");
        }
    }
}