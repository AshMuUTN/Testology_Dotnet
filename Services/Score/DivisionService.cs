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
    public class DivisionService : IDivisionService
    {

        private readonly IDivisionRepository _divisionRepository;
        private readonly IUnitOfWork _unitOfWork;
        public DivisionService(IDivisionRepository divisionRepository, IUnitOfWork unitOfWork)
        {
            _divisionRepository = divisionRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<CreateDivisionResponse> CreateOrUpdateDivisionAsync(Division division)
        {
            // TODO :: CHECK IF GROUP SCORE FILTER BELONGS TO TOKEN USER 
            //https://stackoverflow.com/questions/46112258/how-do-i-get-current-user-in-net-core-web-api-from-jwt-token
            
            if(division.Id == 0){
                _divisionRepository.Add(division);
            } else {
                _divisionRepository.Update(division);
            }
            await _unitOfWork.CompleteAsync();

            return new CreateDivisionResponse(true, null, division);
        }

        public async Task<MessageResponse> DeleteDivisionAsync(int divisionId)
        {
            await _divisionRepository.Delete(divisionId);
            await _unitOfWork.CompleteAsync();

            return new MessageResponse(true, "Division deleted successfully");
        }

        public async Task<IEnumerable<Division>> ListAsync(int subtestId)
        {
            // TODO :: CHECK IF USER IS TOKEN USER 
            //https://stackoverflow.com/questions/46112258/how-do-i-get-current-user-in-net-core-web-api-from-jwt-token
            return await _divisionRepository.ListAsync(subtestId);
        }
    }
}