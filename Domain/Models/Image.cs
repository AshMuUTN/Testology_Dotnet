using System.Collections.Generic;

namespace Testology_Dotnet.Domain.Models
{
    public class Image
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public IEnumerable<Question> Questions { get; set; }

    }
}