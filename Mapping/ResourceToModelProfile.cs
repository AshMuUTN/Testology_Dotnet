using AutoMapper;
using Testology_Dotnet.Domain.Models;
using Testology_Dotnet.Domain.Models.Auth;
using Testology_Dotnet.Domain.Models.Score;
using Testology_Dotnet.Resources;
using Testology_Dotnet.Resources.Auth;
using Testology_Dotnet.Resources.Score;

namespace Testology_Dotnet.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<TestResource, Test>();
            CreateMap<SubtestResource, Subtest>();
            CreateMap<QuestionResourceNoOptions, Question>();
            CreateMap<NumberQuestionResource, Question>();
            CreateMap<TextQuestionResource, Question>();
            CreateMap<NumberOptionResource, Option>();
            CreateMap<TextOptionResource, Option>();
            CreateMap<ImageResource, Image>();
            CreateMap<ProtocolResource, Protocol>();
            CreateMap<AnswerResource, Answer>();
            CreateMap<DivisionResource, Division>();
            CreateMap<GroupResource, Group>();
            CreateMap<ScoreFilterResource, ScoreFilter>();
            CreateMap<GroupScoreFilterResource, GroupScoreFilter>();
            CreateMap<SubtestScoreFilterResource, SubtestScoreFilter>();
            CreateMap<QuestionScoreFilterResource, QuestionScoreFilter>();
            CreateMap<UserCredentialsResource, User>();
            CreateMap<UserUpdateResource, User>();
        }
    }
}