using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Testology_Dotnet.Domain.Models;
using Testology_Dotnet.Domain.Services.Communication;

namespace Testology_Dotnet.Domain.Services
{
    public interface IImageService
    {
        Task<IEnumerable<Image>> ListAsync();
        Task<CreateImageResponse> CreateImageAsync(Image image);
        MessageResponse UploadImage(IFormFile image);
    }
}