using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Testology_Dotnet.Resources
{
    public class ImageResource
    {
        public int Id { get; set; }
        [Required]
        public string Path { get; set; }
        [Required]
        public IFormFile image { get; set; }
    }
}