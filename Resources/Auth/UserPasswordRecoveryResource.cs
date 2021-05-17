using System.ComponentModel.DataAnnotations;

namespace Testology_Dotnet.Resources.Auth
{
    public class UserPasswordRecoveryResource
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [StringLength(255)]
        public string Email { get; set; }
    }
}