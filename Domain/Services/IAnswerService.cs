using System;
using System.Threading.Tasks;
using Testology_Dotnet.Domain.Models;
using Testology_Dotnet.Domain.Services.Communication;

namespace Testology_Dotnet.Domain.Services
{
    public interface IAnswerService
    {
        Task<CreateAnswerResponse> CreateOrUpdateAnswerAsync(Answer answer);
        Task<MessageResponse> DeleteAnswerAsync(int answerId);
    }
}