using System.Collections.Generic;

namespace Testology_Dotnet.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public IList<Test> Tests { get; set; } = new List<Test>();
    }
}