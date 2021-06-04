namespace Testology_Dotnet.Resources.Score
{
    public class ScoreFilterResource
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsForQuestions { get; set; }
        public bool IsForSubtests { get; set; }
        public bool IsForGroups { get; set; }
    }
}