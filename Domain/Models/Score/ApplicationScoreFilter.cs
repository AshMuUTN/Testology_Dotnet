using System.ComponentModel.DataAnnotations;

namespace Testology_Dotnet.Domain.Models.Score
{
    public enum ApplicationScoreFilter
    {
        [Display(Name="arbitrary")]
        Arbitrary = 1,
        [Display(Name="count members")]
        Count = 2,
        [Display(Name="add value")]
        AddValue = 3,
        [Display(Name="add value of")]
        AddValueOf = 4,
        [Display(Name="multiply value")]
        MultiplyValue = 5,
        [Display(Name="multiply value of")]
        MultiplyValueOf = 6,
        [Display(Name="divide value")]
        DivideValue = 7,
        [Display(Name="divide value of")]
        DivideValueOf = 8,
        [Display(Name="range")]
        Range = 9,
        [Display(Name="self")]
        Self = 10
    }
}