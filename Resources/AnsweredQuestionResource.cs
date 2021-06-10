using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Testology_Dotnet.Resources
{
    public class AnsweredQuestionResource
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public IEnumerable<OptionResource> Options { get; set; }
        public ImageResource Image { get; set; }
        public AnswerResource Answer { get; set; }
    }
}