using System.ComponentModel.DataAnnotations;

namespace Testology_Dotnet.Resources
{
    public class NumberOptionResource
    {
        public int Id { get; set; }
        [Required]
        public float Number { get; set; }
        public bool IsCorrect { get; set; } = false;
        public int QuestionId { get; set; }
        public bool Delete { get; set; } 
    }
}