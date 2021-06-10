using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Testology_Dotnet.Resources.Score
{
    public class DivisionResource
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Description { get; set; }
        public IEnumerable<QuestionResource> Questions { get; set; }
        public int SubtestId { get; set; }
    }
}