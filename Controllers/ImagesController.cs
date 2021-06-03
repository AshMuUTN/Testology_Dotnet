using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Testology_Dotnet.Domain.Models;
using Testology_Dotnet.Domain.Services;
using Testology_Dotnet.Resources;

namespace Testology_Dotnet.Controllers
{
    [Route("/api/[controller]")]
    [Authorize(Roles = "Common")]
    public class ImagesController : Controller
    {
        private readonly IImageService _imageService;
        private readonly IMapper _mapper;
        
        public ImagesController(IImageService imageService, IMapper mapper)
        {
            _imageService = imageService;   
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "Common")]
        public async Task<IEnumerable<ImageResource>> GetAllAsync()
        {
            var images = await _imageService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Image>, IEnumerable<ImageResource>>(images);
            return resources;
        }

        [HttpPost, DisableRequestSizeLimit]
        [Authorize(Roles = "Common")]
        public async Task<IActionResult> CreateImageAsync([FromForm] ImageResource body)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var fileImage = body.image;
            var imageFileResponse = _imageService.UploadImage(fileImage);

            if(!imageFileResponse.Success)
            {
                return BadRequest(imageFileResponse.Message);
            }
    
            var image = _mapper.Map<ImageResource, Image>(body);
            image.Path = imageFileResponse.Message;

            var response = await _imageService.CreateImageAsync(image);
            if(!response.Success)
            {
                return BadRequest(response.Message);
            }

            var imageResource = _mapper.Map<Image, ImageResource>(response.Image);
            return Ok(imageResource);
        }
        
    }
}