using System.Collections.Generic;
using System.Threading.Tasks;
using Testology_Dotnet.Domain.Models;
using Testology_Dotnet.Domain.Repositories;
using Testology_Dotnet.Domain.Services;
using Testology_Dotnet.Domain.Services.Communication;

namespace Testology_Dotnet.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public QuestionService(IQuestionRepository questionRepository, IUnitOfWork unitOfWork)
        {
            _questionRepository = questionRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Question>> ListAsync(int subtestId)
        {
            // TODO :: CHECK IF SUBTEST's TEST BELONGS TO TOKEN USER 
            //https://stackoverflow.com/questions/46112258/how-do-i-get-current-user-in-net-core-web-api-from-jwt-token
            return await _questionRepository.ListAsync(subtestId);
        }

        public async Task<CreateQuestionResponse> CreateOrUpdateQuestionAsync(Question question)
        {
            // TODO :: CHECK IF SUBTEST's TEST BELONGS TO TOKEN USER 
            //https://stackoverflow.com/questions/46112258/how-do-i-get-current-user-in-net-core-web-api-from-jwt-token
            
            if(question.Id == 0){
                _questionRepository.Add(question);
            } else {
                _questionRepository.Update(question);
            }
            await _unitOfWork.CompleteAsync();

            return new CreateQuestionResponse(true, null, question);
            
        }

        public async Task<MessageResponse> DeleteQuestionAsync(int questionId)
        {
            await _questionRepository.Delete(questionId);
            await _unitOfWork.CompleteAsync();

            return new MessageResponse(true, "Question deleted successfully");
        }
    }
}