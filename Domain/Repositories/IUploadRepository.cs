using Microsoft.AspNetCore.Http;
using Testology_Dotnet.Domain.Services.Communication;

namespace Testology_Dotnet.Domain.Repositories
{
    public interface IUploadRepository
    {
        MessageResponse UploadImage(IFormFile image);
    }
}