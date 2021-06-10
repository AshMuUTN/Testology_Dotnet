using System.Threading.Tasks;
using Testology_Dotnet.Domain.Models;
using Testology_Dotnet.Domain.Repositories;
using Testology_Dotnet.Domain.Services;
using Testology_Dotnet.Domain.Services.Communication;

namespace Testology_Dotnet.Services
{
    public class AnswerService : IAnswerService
    {
        private readonly IAnswerRepository _answerRepository;
        private readonly IUnitOfWork _unitOfWork;
        public AnswerService(IAnswerRepository answerRepository, IUnitOfWork unitOfWork)
        {
            _answerRepository = answerRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<CreateAnswerResponse> CreateOrUpdateAnswerAsync(Answer answer)
        {
            // TODO :: CHECK IF SUBTEST BELONGS TO TOKEN USER'S TESTS
            //https://stackoverflow.com/questions/46112258/how-do-i-get-current-user-in-net-core-web-api-from-jwt-token
            
            if(answer.Id == 0){
                _answerRepository.Add(answer);
            } else {
                _answerRepository.Update(answer);
            }
            await _unitOfWork.CompleteAsync();

            return new CreateAnswerResponse(true, null, answer);    
        }

        public async Task<MessageResponse> DeleteAnswerAsync(int answerId)
        {
            await _answerRepository.Delete(answerId);
            await _unitOfWork.CompleteAsync();

            return new MessageResponse(true, "Answer deleted successfully");
        }
    }
}