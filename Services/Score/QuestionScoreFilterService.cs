using System.Collections.Generic;
using System.Threading.Tasks;
using Testology_Dotnet.Domain.Models.Score;
using Testology_Dotnet.Domain.Repositories;
using Testology_Dotnet.Domain.Repositories.Score;
using Testology_Dotnet.Domain.Services.Communication;
using Testology_Dotnet.Domain.Services.Communication.Score;
using Testology_Dotnet.Domain.Services.Score;

namespace Testology_Dotnet.Services.Score
{
    public class QuestionScoreFilterService : IQuestionScoreFilterService
    {
        private readonly IQuestionScoreFilterRepository _questionScoreFilterRepository;
        private readonly IUnitOfWork _unitOfWork;
        public QuestionScoreFilterService(IQuestionScoreFilterRepository questionScoreFilterRepository, IUnitOfWork unitOfWork)
        {
            _questionScoreFilterRepository = questionScoreFilterRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<CreateQuestionScoreFilterResponse> CreateOrUpdateQuestionScoreFilterAsync(QuestionScoreFilter questionScoreFilter)
        {
            // TODO :: CHECK IF GROUP SCORE FILTER BELONGS TO TOKEN USER 
            //https://stackoverflow.com/questions/46112258/how-do-i-get-current-user-in-net-core-web-api-from-jwt-token
            
            if(questionScoreFilter.Id == 0){
                _questionScoreFilterRepository.Add(questionScoreFilter);
            } else {
                _questionScoreFilterRepository.Update(questionScoreFilter);
            }
            await _unitOfWork.CompleteAsync();

            return new CreateQuestionScoreFilterResponse(true, null, questionScoreFilter);
        }

        public async Task<MessageResponse> DeleteQuestionScoreFilterAsync(int questionScoreFilterId)
        {
            await _questionScoreFilterRepository.Delete(questionScoreFilterId);
            await _unitOfWork.CompleteAsync();

            return new MessageResponse(true, "Question Score Filter deleted successfully");
        }

        public async Task<IEnumerable<QuestionScoreFilter>> ListAsync()
        {
            // TODO :: CHECK IF USER IS TOKEN USER 
            //https://stackoverflow.com/questions/46112258/how-do-i-get-current-user-in-net-core-web-api-from-jwt-token
            return await _questionScoreFilterRepository.ListAsync();
        }
    }
}