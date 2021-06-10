using System;
using System.ComponentModel.DataAnnotations;

namespace Testology_Dotnet.Domain.Models.Score
{
    public class QuestionScoreFilter
    {
        public int Id { get; set; }
        public int Rank { get; set; }
        [Required]
        public int QuestionId { get; set; }
        public Question Question { get; set; }
        [Required]
        public int ScoreFilterId { get; set; }
        public ScoreFilter ScoreFilter { get; set; }
        public float Value { get; set; }
        public int? To { get; set; }
        public int? From { get; set; }
        public bool isForCorrectAnswers { get; set; } = false;
        public DateTime? DeletedAt { get; set; }
    }
}