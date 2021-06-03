using System.ComponentModel.DataAnnotations;

namespace Testology_Dotnet.Resources
{
    public class OptionResource
    {
        public int Id { get; set; }
        [StringLength(255)]
        public string Text { get; set; }
        public float Number { get; set; }
        public bool IsCorrect { get; set; } = false;
        public int QuestionId { get; set; }
    }
}