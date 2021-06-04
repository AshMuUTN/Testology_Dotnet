using System.Collections.Generic;

namespace Testology_Dotnet.Domain.Models.Score
{
    public class ScoreFilter
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsForQuestions { get; set; }
        public bool IsForSubtests { get; set; }
        public bool IsForGroups { get; set; }
        public IEnumerable<GroupScoreFilter> GroupScoreFilters { get; set; }
        public IEnumerable<QuestionScoreFilter> QuestionScoreFilters { get; set; }
        public IEnumerable<SubtestScoreFilter> SubtestScoreFilters { get; set; }
    }
}