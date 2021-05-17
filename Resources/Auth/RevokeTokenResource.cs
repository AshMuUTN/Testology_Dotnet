using System.ComponentModel.DataAnnotations;

namespace Testology_Dotnet.Resources.Auth
{
    public class RevokeTokenResource
    {
        [Required]
        public string Token { get; set; }
    }
}