using System.ComponentModel.DataAnnotations;

namespace Testology_Dotnet.Resources.Score
{
    public class QuestionScoreFilterResource
    {
        public int Id { get; set; }
        public int Rank { get; set; }
        [Required]
        public int QuestionId { get; set; }
        [Required]
        public int ScoreFilterId { get; set; }
        public ScoreFilterResource ScoreFilter { get; set; }
        public float Value { get; set; }
        public int? To { get; set; }
        public int? From { get; set; }
        public bool isForCorrectAnswers { get; set; } = false;
    }
}