using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Testology_Dotnet.Resources.Score
{
    public class GroupResource
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Description { get; set; }
        public IEnumerable<QuestionResource> Questions { get; set; }
        public IEnumerable<GroupScoreFilterResource> GroupScoreFilters { get; set; }
    }
}