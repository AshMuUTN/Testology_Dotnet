using System.ComponentModel.DataAnnotations.Schema;

namespace Testology_Dotnet.Domain.Models.Auth
{
    [Table("UserRoles")]
    public class UserRole
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}