using System;
using Testology_Dotnet.Domain.Models.Auth;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Testology_Dotnet.Domain.Models.Score;
using System.ComponentModel.DataAnnotations.Schema;

namespace Testology_Dotnet.Domain.Models
{
    public class Subtest
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [StringLength(3000)]
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsScorable { get; set; } = false;
        public bool IsCalculable { get; set; } = false;
        public int TestId { get; set; } 
        public Test Test { get; set; }
        public IEnumerable<Question> Questions { get; set; }
        public DateTime? DeletedAt { get; set; }
        public IEnumerable<SubtestScoreFilter> SubtestScoreFilters { get; set; }
        public IEnumerable<Group> Groups { get; set; }
        public IEnumerable<Division> Divisions { get; set; }
        [NotMapped]
        public float Score { get; set; }
        [NotMapped]
        public int Percentage { get; set; }
        [NotMapped]
        public float Max { get; set; }
    }
}