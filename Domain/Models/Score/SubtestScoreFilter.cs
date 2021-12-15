using System;
using System.ComponentModel.DataAnnotations;

namespace Testology_Dotnet.Domain.Models.Score
{
    public class SubtestScoreFilter : IAppliedScoreFilter
    {
        public int Id { get; set; }
        public int Rank { get; set; }
        [Required]
        public int SubtestId { get; set; }
        public Subtest Subtest { get; set; }
        [Required]
        public int ScoreFilterId { get; set; }
        public ScoreFilter ScoreFilter { get; set; }
        public float Value { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}