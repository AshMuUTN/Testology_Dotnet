using System;
using System.ComponentModel.DataAnnotations;

namespace Testology_Dotnet.Domain.Models
{
    public class Option
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Text { get; set; }
        public float Number { get; set; }
        public bool IsCorrect { get; set; } = false;
        public int QuestionId { get; set; }
        public Question Question { get; set; }
        public bool Deleted { get; set; } =  false;

    }
}