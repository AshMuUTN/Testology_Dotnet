using System.ComponentModel.DataAnnotations;

namespace Testology_Dotnet.Resources.Score
{
    public class SubtestScoreFilterResource
    {
        public int Id { get; set; }
        public int Rank { get; set; }
        [Required]
        public int SubtestId { get; set; }
        [Required]
        public int ScoreFilterId { get; set; }
        public ScoreFilterResource ScoreFilter { get; set; }
        public float Value { get; set; }
    }
}