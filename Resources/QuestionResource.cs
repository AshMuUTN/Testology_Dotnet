using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Testology_Dotnet.Resources
{
    public class QuestionResource
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Text { get; set; }
        [Required]
        public int SubtestId { get; set; }
        public IEnumerable<OptionResource> Options { get; set; }
        public ImageResource Image { get; set; }
        public int? ImageId { get; set; }
    }
}