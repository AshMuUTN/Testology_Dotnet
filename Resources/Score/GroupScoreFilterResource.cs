using System.ComponentModel.DataAnnotations;

namespace Testology_Dotnet.Resources.Score
{
    public class GroupScoreFilterResource
    {
        public int Id { get; set; }
        public int Rank { get; set; }
        [Required]
        public int GroupId { get; set; }
        [Required]
        public int ScoreFilterId { get; set; }
        public ScoreFilterResource ScoreFilter { get; set; }
        public float Value { get; set; }
    }
}