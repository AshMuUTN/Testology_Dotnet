using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Testology_Dotnet.Domain.Models.Score
{
    public class Group
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Description { get; set; }
        public IEnumerable<GroupScoreFilter> GroupScoreFilters { get; set; }
        public int? SubtestId { get; set; }
        public Subtest Subtest { get; set; }
        public DateTime? DeletedAt { get; set; }

    }
}