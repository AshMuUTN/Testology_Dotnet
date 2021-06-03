using System;
using System.Drawing;
using System.IO;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Http;
using Testology_Dotnet.Domain.Repositories;
using Testology_Dotnet.Domain.Services.Communication;
using Testology_Dotnet.Persistence.Contexts;

namespace Testology_Dotnet.Persistence.Repositories
{
    public class UploadRepository : BaseRepository, IUploadRepository 
    {
        public UploadRepository(AppDbContext context) : base(context)
        {
        }

        public MessageResponse UploadImage(IFormFile image)
        {
            try
            {
                var folderName = Path.Combine("Resources", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (image.Length > 0)
                {
                    var fileName = DateTime.Now.ToString("s");
                    fileName += ContentDispositionHeaderValue.Parse(image.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        image.CopyTo(stream);
                    }
                    return new MessageResponse(true, dbPath);
                }
                else
                {
                    return new MessageResponse(false, "Could not save image");
                }
            }
            catch (Exception ex)
            {
                return new MessageResponse(false, $"Internal server error: {ex}");
            }
        }
    }
}