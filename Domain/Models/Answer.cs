using System;
using System.ComponentModel.DataAnnotations;

namespace Testology_Dotnet.Domain.Models
{
    public class Answer
    {
        public int Id { get; set; }
        [Required]
        public int ProtocolId { get; set; }
        [Required]
        public int QuestionId { get; set; }
        public float NumberAnswer { get; set; }
        public int? OptionId { get; set; }
        public Question Question { get; set; }
        public Protocol Protocol { get; set; }
        public Option Option { get; set; }
        public DateTime? DeletedAt { get; set; }
        
    }
}