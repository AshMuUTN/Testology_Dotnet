namespace Testology_Dotnet.Domain.Models.Score
{
    public interface IAppliedScoreFilter
    {
        int Id { get; set; }
        int Rank { get; set; }
        int ScoreFilterId { get; set; }
        ScoreFilter ScoreFilter { get; set; }
        float Value { get; set; }
    }
}