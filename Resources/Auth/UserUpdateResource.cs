using System.ComponentModel.DataAnnotations;

namespace Testology_Dotnet.Resources.Auth
{
    public class UserUpdateResource
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [StringLength(255)]
        public string Email { get; set; }
        [Required]
        [StringLength(32)]
        public string Password { get; set; }
    }
    
}