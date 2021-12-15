using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Testology_Dotnet.Domain.Models.Score;

namespace Testology_Dotnet.Domain.Models
{
    public class Option
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        // TODO investigate 'nullable' context and its implications in order to 
        // confidently implement it here and let Text string be nullable, word 'none' is workaround
        // that can be quickly replaced with nulls once nullable context has been createdß
        // https://docs.microsoft.com/en-us/dotnet/csharp/nullable-references#nullable-contexts
        public string Text { get; set; } = "none"; 
        public float Number { get; set; }
        public bool IsCorrect { get; set; } = false;
        public int QuestionId { get; set; }
        public Question Question { get; set; }
        public IEnumerable<GroupScoreFilter> GroupScoreFilters { get; set; }
        public bool Deleted { get; set; } =  false;
        public IEnumerable<Answer> Answers { get; set; }

    }
}