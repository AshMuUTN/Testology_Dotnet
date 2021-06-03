using AutoMapper;
using Testology_Dotnet.Domain.Models;
using Testology_Dotnet.Domain.Models.Auth;
using Testology_Dotnet.Resources;
using Testology_Dotnet.Resources.Auth;

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
            CreateMap<UserCredentialsResource, User>();
            CreateMap<UserUpdateResource, User>();
        }
    }
}