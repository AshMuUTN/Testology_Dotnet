using System;
using System.ComponentModel.DataAnnotations;

namespace Testology_Dotnet.Domain.Models.Score
{
    public class GroupScoreFilter : IAppliedScoreFilter
    {
        public int Id { get; set; }
        public int Rank { get; set; }
        [Required]
        public int GroupId { get; set; }
        public Group Group { get; set; }
        [Required]
        public int ScoreFilterId { get; set; }
        public ScoreFilter ScoreFilter { get; set; }
        public float Value { get; set; }
        public int OptionId { get; set; }
        public Option Option { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}