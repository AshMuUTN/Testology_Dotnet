using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace Testology_Dotnet.Domain.Models
{
    public class Question
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Text { get; set; }
        public int SubtestId { get; set; }
        public Subtest Subtest { get; set; }
        public IEnumerable<Option> Options { get; set; }
        public DateTime? DeletedAt { get; set; }
        public int? ImageId { get; set; }
        public Image Image { get; set; }
    }
}