using System.ComponentModel.DataAnnotations;

namespace Testology_Dotnet.Resources
{
    public class TextOptionResource
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Text { get; set; }
        public bool IsCorrect { get; set; } = false;
        public int QuestionId { get; set; }
        public bool Delete { get; set; } 
    }
}