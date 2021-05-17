using System.Collections.Generic;

namespace Testology_Dotnet.Resources.Auth
{
    public class UserResource
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
}