using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Testology_Dotnet.Domain.Models;
using Testology_Dotnet.Domain.Repositories;
using Testology_Dotnet.Domain.Services;
using Testology_Dotnet.Domain.Services.Communication;
using Testology_Dotnet.Resources;

namespace Testology_Dotnet.Services
{
    public class ImageService : IImageService
    {
        private readonly IImageRepository _imageRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUploadRepository _uploadRepository;

        public ImageService(IImageRepository imageRepository, IUnitOfWork unitOfWork, IUploadRepository uploadRepository)
        {
            _imageRepository = imageRepository;
            _unitOfWork = unitOfWork;
            _uploadRepository = uploadRepository;
        }
        public async Task<CreateImageResponse> CreateImageAsync(Image image)
        {
            _imageRepository.Add(image);
            await _unitOfWork.CompleteAsync();

            return new CreateImageResponse(true, null, image);
        }

        public async Task<IEnumerable<Image>> ListAsync()
        {
            // TODO :: ONLY RETRIEVE IMAGES THAT BELONGS TO TOKEN USER 
            //https://stackoverflow.com/questions/46112258/how-do-i-get-current-user-in-net-core-web-api-from-jwt-token
            return await _imageRepository.ListAsync();
        }

        public MessageResponse UploadImage(IFormFile image)
        {
            return _uploadRepository.UploadImage(image);
        }
    }
}