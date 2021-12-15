using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Testology_Dotnet.Resources
{
    public class QuestionResourceNoOptions
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Text { get; set; }
        [Required]
        public int SubtestId { get; set; }
        public int? ImageId { get; set; }
        public IEnumerable<OptionResource> options { get; set; } // Could happen if options being deletedß
    }
}