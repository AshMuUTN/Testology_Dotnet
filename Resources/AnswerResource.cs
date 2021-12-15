using System.ComponentModel.DataAnnotations;

namespace Testology_Dotnet.Resources
{
    public class AnswerResource
    {
        public int Id { get; set; }
        [Required]
        public int ProtocolId { get; set; }
        [Required]
        public int QuestionId { get; set; }
        public float NumberAnswer { get; set; }
        public string TextAnswer { get; set; }
        public int? OptionId { get; set; }
        public OptionResource Option { get; set; }
        
    }
}